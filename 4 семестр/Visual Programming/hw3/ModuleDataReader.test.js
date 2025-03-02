const ModuleGetData = require('./ModuleGetData');
const ModuleDataReader = require('./ModuleDataReader');

test("Reading data from remote resource", async () => 
{
    const fMock = jest.spyOn(ModuleGetData, "GetData");
    fMock.mockImplementation(() =>new Promise((resolve) => resolve(
        [
            {
              breed: 'Abyssinian',
              country: 'Ethiopia',
              origin: 'Natural/Standard',  
              coat: 'Short',
              pattern: 'Ticked'
            },
            {
              breed: 'Aegean',
              country: 'Greece',
              origin: 'Natural/Standard',  
              coat: 'Semi-long',
              pattern: 'Bi- or tri-colored'
            }
        ]
    )));

    const temp = await ModuleDataReader.DataReader("test", "country");
    expect(fMock).toHaveBeenCalledTimes(1);
    fMock.mockRestore();
    
    const expectedMap = new Map([["Ethiopia", 1], ["Greece", 1]]);
    expect(temp).toEqual(expectedMap);
});
