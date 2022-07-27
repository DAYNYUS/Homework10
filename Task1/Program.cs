// Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа в группе друг на друга не делились? 
// Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰. Например, для N = 50, M получается 6
/*
Группа 1: 1
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 7 16 24 36 40
Группа 6: 5 32 48

Группа 1: 1
Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 16 24 36 40
Группа 6: 32 48    */

long n = InputNumbers("Введите число N: ");

long[] arrayTemp = CreateArray(n);
CreateGroups(arrayTemp);

void CreateGroups(long[] arrayCheck)
{
  long[] arrayTemp = new long[arrayCheck.Length];
  long m = 1;
  long count = 0;
  long tempNumberA = 0;
  long tempNumberB = 0;
  long tempSwitch = 0;
  
  for (long i = 0; i < arrayCheck.Length; i++)
  {
    Array.Clear(arrayTemp);
    count = 0;
    if (arrayCheck[i] != 0)
    {
      arrayTemp[count] = arrayCheck[i];
      tempNumberB = arrayCheck[i];

      for (long j = i; j < arrayCheck.Length; j++)
      {
        if (arrayCheck[j] % tempNumberB != 0 || arrayCheck[j] / tempNumberB == 1)
        {
          tempSwitch = 0;
          tempNumberA = arrayCheck[j];
          for (long k = 0; k < count; k++)
          {
            if (tempNumberA % arrayTemp[k] == 0) tempSwitch++;
          }
          if (tempSwitch == 0)
          {
            arrayTemp[count] = arrayCheck[j];
            count++;
            arrayCheck[j] = 0;
          }
        }
      }
      Console.WriteLine($"Группа {m++}: {PrintIntArray(arrayTemp)}");
    }
  }
}

long InputNumbers(string input)
{
  Console.Write(input);
  long output = Convert.ToInt64(Console.ReadLine());
  return output;
}

long[] CreateArray(long n)
{
  long[] temp = new long[n];
  for (long i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = i + 1;
  }
  return temp;
}

string PrintIntArray(long[] array)
{
  string result = string.Empty;
  for (long i = 0; i < array.Length; i++)
  {
    if (array[i] != 0) result += $"{array[i],1} ";
  }
  return result;
}
