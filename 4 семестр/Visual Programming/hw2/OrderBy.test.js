const OrderBy = require('./OrderBy');

test('Order by name and age', () =>
{
    const data = [
        { name: "John", age: 30 },
        { name: "Jane", age: 25 },
        { name: "John", age: 20 }
    ];

    const correctAnswer = [
        { name: 'Jane', age: 25 },
        { name: 'John', age: 20 },
        { name: 'John', age: 30 }
    ];
    
    const sortedData = OrderBy(data, ["name", "age"]);
    expect(sortedData).toEqual(correctAnswer);
});

test('Get error on input data type', () =>
{
    const data = "rubber duck";

    expect(() => OrderBy(data, ["name", "age"])).toThrow("First argument must be an array of objects.");
});

test('Get error on input data field', () =>
{
    const data = [
        { name: "John", age: 30 },
        { name: "Jane" },
        { name: "John", age: 20 }
    ];

    expect(() => OrderBy(data, ["name", "age"])).toThrow('Property "age" is missing in one of the objects.');
});