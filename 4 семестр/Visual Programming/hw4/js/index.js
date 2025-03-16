import { InsertToHTML } from './InsertHTML.js';
import { ItemBook } from "./DisplayItemBook.js";

const data = await fetch("https://fakeapi.extendsclass.com/books");
const json = await data.json();

json.sort((a, b) => {
    const titleA = a.title.toLowerCase();
    const titleB = b.title.toLowerCase();

    if (titleA < titleB) { return -1; }
    if (titleA > titleB) { return 1; }
    return 0;
});

const bookItems = await Promise.all(json.map(async element => {
    let url = "img/image.png";
    try
    {
        const temp = await fetch(`https://www.googleapis.com/books/v1/volumes?q=isbn:${element["isbn"]}`);
        const tempJSON = await temp.json();
        url = tempJSON.items[0].volumeInfo.imageLinks.thumbnail;
    } 
    catch (err)
    {
        console.error(err);
    }

    return ItemBook(url, element["title"], element["authors"]);
}));

bookItems.forEach(item => {
    InsertToHTML("root", item);
});
