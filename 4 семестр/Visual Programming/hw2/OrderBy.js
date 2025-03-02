function OrderBy(arrToSort, arrOfFields)
{
  if (!Array.isArray(arrToSort) || !arrToSort.every(item => typeof item === 'object' && item !== null))
  {
    throw new Error("First argument must be an array of objects.");
  }

  arrToSort.forEach(element => {
    arrOfFields.forEach(field => {
      if (!(field in element))
      {
        throw new Error(`Property "${field}" is missing in one of the objects.`);
      }
    });
  });

  const sortedArray = [...arrToSort];

  sortedArray.sort((a, b) => {
    for (let field of arrOfFields)
    {
      if (a[field] < b[field]) return -1;
      if (a[field] > b[field]) return 1;
    }

    return 0;
  });

  return sortedArray;
}

module.exports = OrderBy;
