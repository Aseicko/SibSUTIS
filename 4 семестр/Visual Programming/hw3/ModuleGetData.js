async function GetData(urlToData)
{
    var url = urlToData;
    var output = [];
    
    try
    {
        var json;
        do
        {
            var response = await fetch(url);
            json = await response.json();

            url = json.next_page_url;
            json.data.forEach(item => { output.push(item); });

        }
        while(json.next_page_url != null);
    }
    catch (error)
    {
      console.error(error.message);
    }

    return output;
}

module.exports.GetData = GetData;