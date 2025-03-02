async function ProcessData(data, field)
{
    var output = new Map();

    data.forEach(element => {
        if (!(field in element))
        { 
            throw new Error(`Property "${field}" is missing in one of the objects.`);
        }

        if(output.has(element[field]))
        {
            output.set(element[field], output.get(element[field]) + 1);
        }
        else
        {
            output.set(element[field], 1);
        }
    });
    output = new Map([...output.entries()].sort());
    
    return output;
}

module.exports.ProcessData = ProcessData;