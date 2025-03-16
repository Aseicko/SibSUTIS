export function ItemBook(url, title, author){
    return (
        `<article>
            <img src="${url}" alt="${title}"/>
            <h1>${title}</h1>
            <h2>${author}</h2>
        </article>`
    );
}
