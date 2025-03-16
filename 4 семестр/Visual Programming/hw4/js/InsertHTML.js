export function InsertToHTML(rootHTML, newHtml)
{
    const where = document.getElementById(rootHTML);
    return where.innerHTML += newHtml;
}
