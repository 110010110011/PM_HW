# HW1 Template
Домашнее задания HW1.

Содержит 5 заданий.

Темы : Арифметика, Условные операторы, Циклы, Аргументы командной строки, Работа со строками.

## Структура исходного кода
Каталог с решением имеет следующую структуру :
- editorconfig - файл с правилами форматирования кода; запрещен к модификации;
- Directory.Build.props - файл с настройки решения; запрещен к модификации;
- Hw1.Exercise1 - проект приложения “Простые числа”;
    - Program.cs - класс точка входа в приложения; не требует доработок;
    - PrimeNumbersApplication.cs - основной класс приложения, который должен быть доработан студентом в соответствии заданием;
- Hw1.Exercise2 - проект приложения “Площадь фигуры”;
    - Program.cs - класс точка входа в приложения; не требует доработок;
    - AreaCalcApplication.cs - основной класс приложения, который должен быть доработан студентом в соответствии заданием;
- Hw1.Exercise3 - проект приложения-игры “Камень-Ножницы-Бумага”;
    - Program.cs - класс точка входа в приложения; не требует доработок;
    - GameApplication.cs - основной класс приложения, который должен быть доработан студентом в соответствии заданием;
- Hw1.Exercise4 - проект приложения “Статистика”;
    - Program.cs - класс точка входа в приложения; не требует доработок;
    - ArrayStatApplication.cs - основной класс приложения, который должен быть доработан студентом в соответствии заданием;
- Hw1.Exercise5 - проект приложения “Калькулятор”;
    - Program.cs - класс точка входа в приложения; не требует доработок;
    - CalcApplication.cs - основной класс приложения, который должен быть доработан студентом в соответствии заданием;            
- Hw1.Tests - тестовый проект для всех заданий; запрещен к модификации.

## Задание 1. Приложение “Простые числа”
Разработать приложение “Простые числа”.

### Введение
Консольное приложение “Простые числа” позволяет найти простые числа в заданом диапазоне и вывести их на стандартное устройство вывода. 
Границы диапазона задаются через аргументы командной строки.

### Задание
Необходимо разработать приложение “Простые числа”, которое выводит список простых чисел в заданом диапазоне на стандартное устройство вывода.

Требования :
- Приложения принимает границы диапазона для поиска простых чисел через аргументы командной строки :
    - Аргументы передаются в виде 2х целых чисел - границы диапазона поиска [from, to];
    - Если аргумент from > to, то их следует поменять местами;
    - Если аргументы не переданы или неудается их привести к целому числу int :
        - приложение ничего не выводит;
        - приложение завершает выполнение с кодом -1 (аргументы не заданы или заданы неверно).
- Приложение ищет простые числа в заданом диапазоне, включая границы диапазона.
- Приложение выводит числа в одну строку, разделяя их ";".
- При выводе на стандартное устройство вывода, признак перевода строки не добавляется.

**Для выполнения задания, необходимо предоставить свою реализацию метода Run(...) существующего класса Hw1.Exercise1.PrimeNumbersApplication.**

Пример использования :
```
C:\Users\test.user\demo.path>Hw1.Exercise1.exe -3 3
2;3;
```

### Советы
- Чтобы при выводе на стандартное устройство вывода не добавлялась новая строка, следует использовать метод `System.Console.Write(...)` вместо `System.Console.WriteLine(...)`.
- Чтобы объединить строки - используйте метод `System.String.Concat(...)`.
- Чтобы объединить строки, помещая между ними заданный разделитель, следует использовать метод `System.String.Join(...)`.
- Чтобы определить длину массива - используйте свойство `Length`.
- Чтобы обратится к элементу массива по номеру n - используйте индексатор `[n]`.
- Чтобы попытаться привести строку к числу - используйте `int.TryParse(...)`.

### Чек-лист
- Реализован метод Run(...) существующего класса Hw1.Exercise1.PrimeNumbersApplication.
- При поиске простых чисел, включаются границы диапазонов.
- Приложение не "падает", при попытке привести строку в неправильном формате к числу.
- Решение проходит все тест-кейсы, которые содержит тестовый проект.
- Нет сообщения об ошибках касательно форматирования кода.
- Код реализации загружен в приватный репозиторий, а коммит отправлен в LMS.

## Задание 2. Приложение “Площадь фигуры”
Разработать приложение “Площадь фигуры”.

### Введение
Консольное приложение “Площадь фигуры” позволяет вычислить площадь одной из фигур :
- Круг (Circle) - через радиус (1 аргумент);
- Квадрат (Square) - через длину одной из сторон (1 аргумент);
- Прямоугольник (Rect) - через длину двух сторон (2 аргумента);
- Треугольник (Triangle) - через длину основания и высоту (2 аргумента) или через длины всех трех сторон (3 аргумента);

Искомая фигура и ее размерности задаются через аргументы командной строки.

### Задание
Необходимо разработать приложение “Площадь фигуры”, которое позволяет вычислить площадь одной из доступных фигур и выводит результат на стандартное устройство вывода.

Требования :
- Приложения принимает название фигуры и ее размерности через аргументы командной строки :
    - Первый аргумент - название фигуры, остальные агрументы - размерности фигуры;
    - Если аргументы не переданы или неудается их привести к числу типа double :
        - приложение ничего не выводит;
        - приложение завершает выполнение с кодом -1 (аргументы не заданы или заданы неверно).
    - Если аргументы заданы верно, но выполнить расчет невозможно (например, задан отрицательный радиус для круга), то приложение завершает выполнение с кодом -2 (невозможно рассчитать площадь фигуры для заданых размерностей).
- Приложение должно быть нечувствительно к регистру. Название фигуры может задаваться в любом регистре; например : `Rect` и `rect` - оба варианта правильные.
- Приложение работает с числами с плавающей запятой (точкой).
- Приложение должно быть независимо от текущей культуры - принимать размерности фигуры, как с плавающей точкой, так и с плавающей запятой.

Список фигур и их размерностей :
| Фигура  | Размерности           | Кол-во аргументов (фигура + размерности)|
|---------|:----------------------|:----------------------------------------|
| Circle  | Radius                | 2                                       |
| Square  | Side length           | 2                                       |
| Rect    | Width, Height         | 3                                       |
| Triangle| Base, Height          | 3                                       |
| Triangle| Side-1, Side-2, Side-3| 4                                       |


**Для выполнения задания, необходимо предоставить свою реализацию метода Run(...) существующего класса Hw1.Exercise2.AreaCalcApplication.**

Пример использования :
```
C:\Users\test.user\demo.path>Hw1.Exercise2.exe Triangle 30.1 30,2
454.51
```

### Советы
- Чтобы сравнить строки независимо от регистра, можно воспользоваться методом `Equals(...)` класса `System.StringComparer.OrdinalIgnoreCase`.
- Чтобы привести строку к необходимому регистру, можно воспользоваться одним из методов класса `System.String` : `ToLower()`,`ToLowerInvariant()`, `ToUpper()`, `ToUpperInvariant()`.
- Чтобы попытаться привести строку к числу c плавающей запятой - используйте `double.TryParse(...)`.
- Чтобы делать приведение строки к числу c плавающей запятой, не зависимо от текущей культуры - замените запятые на точки, а потом используйте инвариантную культуру для приведения :
``` cpp
// using System.Globalization;
str = str.Replace(',', '.');
return double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var value);
```

### Чек-лист
- Реализован метод Run(...) существующего класса Hw1.Exercise2.AreaCalcApplication.
- Приложение поддерживает все типы фигур, согласно заданию.
- Приложение не чувствительно к регистру аргументов командной строки.
- Приложение не "падает", при попытке привести строку в неправильном формате к числу с плавающей запятой (точкой).
- Решение проходит все тест-кейсы, которые содержит тестовый проект.
- Нет сообщения об ошибках касательно форматирования кода.
- Код реализации загружен в приватный репозиторий, а коммит отправлен в LMS.

## Задание 3. Игра “Камень-Ножницы-Бумага”
Разработать игровое приложение “Камень-Ножницы-Бумага”.

### Введение
Консольное приложение “Камень-Ножницы-Бумага” позволяет игроку сразится с компьютером в знаменитую детскую игру.
Игрок, через аргументы командной строки, задает одну из фигур :
- Камень (Rock) - бьет ножницы, проигрывает бумаге;
- Ножницы (Scissors) - бьет бумагу, проигрывает камню;
- Бумага (Paper) - бьет камень, проигрывает ножницам;
в свою очередь программа случайным образом загадывает свою фигуру; результат поединка выводится на стандартное устройство вывода.
Формат результата строго стандартизирован.

### Задание
Необходимо разработать игровое приложение “Камень-Ножницы-Бумага” которое позволяет игроку сразится с компьютером в знаменитую детскую игру.

Требования :
- Приложения принимает название фигуры через аргументы командной строки :
    - Первый аргумент - название фигуры; остальные аргументы (если они есть) игнорируются;
    - Если название фигуры не передано, или не входит в диапазон допустимых значений [Rock, Scissors, Paper] :
        - приложение ничего не выводит;
        - приложение завершает выполнение с кодом -1 (аргументы не заданы или заданы неверно).
    - Приложение должно быть нечувствительно к регистру фигуры игрока.
- Приложение определяет победителя согласно таблице со списком фигур (см. ниже).
- Приложение случайным образом "загадывает" одну из фигур.
- Приложение должно выводить результат поединка в строго заданом формате (см. ниже).
- Приложение выводит ключевые слова (участники, фигуры, исходы) в правильном регистре (PascalCase); даже если игрок задал фигуру `rOCK` - в результатах поединка, фигура должна следовать формату и регистру.

Список фигур :
| Фигура   | Бьет (Win)| Проигрывает (Lose)| Ничья (Draw)|
|----------|:----------|:------------------|:------------|
| Rock     | Scissors  | Paper             | Rock        |
| Scissors | Paper     | Rock              | Scissors    |
| Paper    | Rock      | Scissors          | Paper       |

Список возможных исходов поединка (для конкретного участника) :
| Исход| Комментарий           |
|------|:----------------------|
| Win  | Победа участника      |
| Lose | Проигрыш участника    |
| Draw | Ничья                 |

Формат вывода результата поединка :
- `{0}={1}:{2}`, где
    - 0 - Участник ["Player", "Computer"],
    - 1 - Фигура участника ["Rock", "Paper", "Scissors"],
    - 2 - Исход для участника ["Win", "Lose", "Draw"];
- Так как в игре, всегда 2 участника (Player и Computer), то в результате поединка всегда будет 2 записи;
- Пример :
```
Player=Rock:Draw
Computer=Rock:Draw
```

**Для выполнения задания, необходимо предоставить свою реализацию метода Run(...) существующего класса Hw1.Exercise3.GameApplication.**

Пример использования :
```
C:\Users\test.user\demo.path>Hw1.Exercise3.exe rock
Player=Rock:Draw
Computer=Rock:Draw
```

### Советы
- Чтобы получить случайное число, можно воспользоваться классом `System.Random`.

### Чек-лист
- Реализован метод Run(...) существующего класса Hw1.Exercise3.GameApplication.
- Приложение поддерживает все типы фигур, согласно заданию.
- Приложение не чувствительно к регистру аргументов командной строки.
- Приложение выводит результаты поединка согласно с заданым форматом.
- Решение проходит все тест-кейсы, которые содержит тестовый проект.
- Нет сообщения об ошибках касательно форматирования кода.
- Код реализации загружен в приватный репозиторий, а коммит отправлен в LMS.

## Задание 4. Приложение "Статистика" (по массиву).
Разработать приложение-помощник для подсчета статистики по массиву целых чисел.

### Введение
Консольное приложение “Статистика” позволяет пользователю получить статистики по массиву целых чисел.
Пользователь, через аргументы командной строки, передает набор целых чисел.
Приложение подсчитывает следующие характеристики массива :
- Min - минимальный элемент массива (значение);
- Max - максимальный элемент массива (значение);
- Sum - сумма элементов массива;
- Average - среднее арифметическое (значение с плавающей запятой (точкой));
- Count - количество элементов в массиве;
- Sorted - элементы массива, отсортированные по возрастанию.

### Задание
Необходимо разработать приложение-помощник для подсчета статистики по массиву целых чисел.

Требования :
- Приложение не использует возможности `LINQ` (пространство имен `System.Linq`)!
- Приложения принимает последовательность чисел через аргументы командной строки :
    - Аргументы разделяются пробелами;
    - Если аргументы не переданы или неудается их привести к числу типа int :
        - приложение ничего не выводит;
        - приложение завершает выполнение с кодом -1 (аргументы не заданы или заданы неверно).
- Приложение подсчитывает и выводит среднее арифметическое `Average` типом `double`. Например для массива из чисел [1, 2] - среднее арифметическое = 1.5.
- Приложение выводит элементы массива, отсортированные по возрастанию `Sorted` - разделяя элементы точкой с запятой без пробелов. Например для массива из чисел [1, 2] - `Sorted=1;2`.
- Приложение выводить результат в строго заданом формате (см. ниже).

Формат вывода результатов подсчета :
- `{0}={1}`, где
    - 0 - Характеристика массива [Min, Max, Sum, Average, Count, Sorted],
    - 1 - Значение характеристики.
- Пример для массива [1, 2] :
```
Min=1
Max=2
Sum=3
Average=1.5
Count=2
Sorted=1;2
```

**Для выполнения задания, необходимо предоставить свою реализацию метода Run(...) существующего класса Hw1.Exercise4.ArrayStatApplication.**

Пример использования :
```
C:\Users\test.user\demo.path>Hw1.Exercise4.exe 2 1
Min=1
Max=2
Sum=3
Average=1.5
Count=2
Sorted=1;2
```

### Чек-лист
- Реализован метод Run(...) существующего класса Hw1.Exercise4.ArrayStatApplication.
- Не используется пространство имен `System.Linq`.
- Приложение не "падает", при попытке привести строку в неправильном формате к числу.
- Приложение верно подсчитывает среднее среднее арифметическое `Average`(использован тип `double`).
- Решение проходит все тест-кейсы, которые содержит тестовый проект.
- Нет сообщения об ошибках касательно форматирования кода.
- Код реализации загружен в приватный репозиторий, а коммит отправлен в LMS.

## Задание 5. Приложение "Калькулятор".
Разработать приложение калькулятор для выполнения арифметических операций с числами с плавоющей запятой (точкой).

### Введение
Консольное приложение “Калькулятор” позволяет пользователю оперативно вычислять значение простых математических выражений.
Пользователь, через аргументы командной строки, передает оператор и один или два операнда.
Приложение пытается разобрать математическое выражение и рассчитать результат.
Приложение работает с числами с плавающей запятой, кроме операции рассчета факториала.

### Задание
Необходимо приложение калькулятор для выполнения арифметических операций.

Требования :
- Приложения принимает математическое выражение через аргументы командной строки :
    - Математическое выражение может сожержать промежуточные пробелы (например: `- 2 - - 1`);
    - Если аргументы не переданы или неудается их привести к числу типа double или long (для рассчета факториала) :
        - приложение ничего не выводит;
        - приложение завершает выполнение с кодом -1 (аргументы не заданы или заданы неверно).
    - Если аргументы заданы верно, но выполнить расчет невозможно (например, выполнить деление на ноль), то приложение завершает выполнение с кодом -2 (невозможно выполнить рассчет).
- Приложение выводить только результат - число, без дополнительных комментариев и пробелов.
- Приложение должно быть независимо от текущей культуры - принимать размерности фигуры, как с плавающей точкой, так и с плавающей запятой.
- Приложение поддерживает весь список операций (см. ниже).

Список операций, которые должно поддерживать приложение :
| Операция        | Операторы  | Тип оператора| Тип данных | Ограничения                             | Пример выражения | Комментарий                                  |
|-----------------|:-----------|:-------------|:-----------|:----------------------------------------|:-----------------|:---------------------------------------------|
| Эхо             | нет        | Унарный      | `double`   | Без специальных ограничений             | `-2`             | выводит то же число, что было подано на вход |
| Факториал       | `!`        | Унарный      | `long`     | Валидный диапазон [0, 18] включ.        | `2!`             | нет                                          |
| Сложение        | `+`        | Бинарный     | `double`   | Без специальных ограничений             | `-1+-2`          | нет                                          |
| Вычитание       | `-`        | Бинарный     | `double`   | Без специальных ограничений             | `-1--2`          | нет                                          |
| Произведение    | `*`,`x`,`X`| Бинарный     | `double`   | Без специальных ограничений             | `-1x-2`          | нет                                          |
| Деление         | `\`,`/`    | Бинарный     | `double`   | Деление на ноль - запрещено             | `-1\-2`          | нет                                          |
| Возв. в степень | `^`        | Бинарный     | `double`   | Возв. отриц. чисел в степень (0, 1.0)   | `-10.2^4,5`      | нет                                          |

**Для выполнения задания, необходимо предоставить свою реализацию метода Run(...) существующего класса Hw1.Exercise5.CalcApplication.**

Пример использования :
```
C:\Users\test.user\demo.path>Hw1.Exercise5.exe - 1,23 * - 2.34
2.8782
```

Примеры правильных математических выражений :
| Выражение    | Результат  | Код завершения|
|--------------|:-----------|:--------------|
|`-1.23+-2,34` |`-3.57`     |0              |
|`-1.23`       |`-1.23`     |0              |
|`- 1 . 2 3`   |`-1.23`     |0              |
|`2!`          |`2`         |0              |

Примеры неправильных математических выражений :
| Выражение    | Результат  | Код завершения|
|--------------|:-----------|:--------------|
|`1 plus 2`    |нет         |-1             |
|`-1.23++2,34` |нет         |-1             |
|`1.23+*2,34`  |нет         |-1             |
|`1.23-a.bc`   |нет         |-1             |
|`-5!`         |нет         |-2             |
|`5\0`         |нет         |-2             |
|`-5 ^ 0.5`    |нет         |-2             |

### Советы
- Так как пользователь может вставлять произвольное количество промежуточных пробелов, то количество аргументов командной строки также может быть произвольным. Стоит использовать метод `Concat` класса `System.String`, чтобы предварительно объеденить все части математического выражения.

### Чек-лист
- Реализован метод Run(...) существующего класса Hw1.Exercise5.CalcApplication.
- Приложение не "падает", при попытке привести строку в неправильном формате к числу.
- Решение проходит все тест-кейсы, которые содержит тестовый проект.
- Нет сообщения об ошибках касательно форматирования кода.
- Код реализации загружен в приватный репозиторий, а коммит отправлен в LMS.