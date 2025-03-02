const ModuleGetData = require('./ModuleGetData');
const ModuleProcessData = require('./ModuleProcessData');

async function DataReader(urlToData, field)
{ 
    const temp = await ModuleGetData.GetData(urlToData);

    return await ModuleProcessData.ProcessData(temp, field);
}

module.exports.DataReader = DataReader;
