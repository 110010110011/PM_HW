# HW8
Домашнее задание HW8.
```
├──.editorconfig            правила форматирования кода; запрещен к модификации;
├──.gitignore               скрывает файлы и папки от системы контроля версий Git;
├──.gitlab-ci.yml           конфигурация GitLab CI/CD;
├──Directory.Build.props    файл с настройками решения; запрещен к модификации;
├──src                      каталог с исходными файлами приложения, все основные изменения здесь;
│  ├──Common                 - проект с общими классами для приложений;
│  ├──Hw5.Exercise0          - проект приложения “Валидация через атрибуты”;
├──tests                    каталог с исходными файлами тестов, запрещен к модификации;
│  ├──Hw5.Exercise0.Tests    - проект с тестами приложения “Валидация через атрибуты”;
├──README.md                этот файл ¯\_(ツ)_/¯;
├──Hw5.sln                  файл решения для открытия в предпочитаемой IDE;
```
# Задания
**Темы** : SOLID, DI-Containers

Все задания уже имеют программный каркас. Задача студента:
- реализовать недостающие блоки функциональности
    > Ищи по тексту // TODO: или "Should be implemented by executor"
- сделать так, чтоб все тесты проходили :)

## Задание 0. Конвертер валют

Пользователю необходимо приложение для конвертации валют.
Пользователь вводит в командную строку 3 символа исходной валюты,
3 символа желаемой валюты и сумму к обмену (неотрицательное число).
Приложение пытается актуализировать файл содержащий курсы валют.
Приложение берет курсы валют из файла и в случае, если курсы исходной и желаемой валют определены,
то производит конвертацию.
Если курсы валют не определены или файл с курсами валют отсутствует - сообщить об ошибке пользователю.
В качестве источника данных решено использовать бесплатный сервис НБУ.

### Источник данных
`https://bank.gov.ua/ua/open-data/api-dev`

`https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json`

### Задание:
- Взаимодействие с программой происходит с командной строки;
- Для корректной работы программы, в командную строку пользователю необходимо ввести (в соотв. порядке):
  - Исходная валюта: не пустая строка; 3 символа;
  - Желаемая валюта: не пустая строка; 3 символа;
  - Сумма: неотрицательное число типа decimal;
- Ошибки ввода: выход из программы с `ReturnCode` равным `InvalidArgs`;
- Курсы валют хранятся в кеше - файле с названием `cache.json`;
- Если дата обменного курса валют сегоднешняя - обновлять кеш не нужно и можно сразу приступать к расчетам;
- Если кеш устарел - необходимо обновить его отправив запрос `GET` на API НБУ;
- Структура файла `cache.json` соответствует структуре ответа API НБУ. Что позволяет сохранить
содержимое ответа от API НБУ в файл `cache.json` без изменений;
- Если во время обращение к API НБУ, произошла ошибка, то сообщить пользователю, что обновить курсы не удалось.
Выйти из программы с `ReturnCode` равным `Error`;
- Найти валютные пары в `cache.json` и с учетом двойной конвертации (т.к. курсы НБУ заданы по отношению к UAH)
  выдать результаты пользователю:
  - [ ] Показать найденный курс валют;
  - [ ] Указать дату, на которую актуален курс;
  - [ ] Показать сумму в желаемой валюте;
  - [ ] Строка формата - по усмотрению программиста; главное отразить: курс, дату, сумму в желаемой валюте.
- Если не удалось найти заданные валютные пары, то сообщить об ошибке пользователю и выйти с `ReturnCode` равным `Error`;
- Считаем, что если файл `cache.json` существует, то содержимое - валидный JSON. Значит нет необходимости обрабатывать ошибки десериализации JSON;
- Работа с JSON:
  - Для работы (десериализации) с `cache.json` необходимо создать соответствующие классы;
  - Для десериализации содержимого cache.json необходимо использовать классы с неймпсейса `System.Text.Json`

### Чек-лист
- [ ] Код приложения написан с учетом принципов SOLID
- [ ] Приложение обрабатывает некорректный ввод и выходит с `ReturnCode` равным `InvalidArgs` ;
  в случае ошибки валидации аргументов
- [ ] Работа с файлами идёт через `IFileSystemProvider` для чтения/записи, проверки существования файла.
  Дальнейшая работа с `Stream` на усмотрение студента
- [ ] Тип данных для Суммы валюты подлежащей обмену - decimal;
- [ ] Для записи JSON файла используется `System.Text.Json`;
- [ ] Приложение перехватывает ошибки запросов  к API НБУ и проверяет HTTP status code;
- [ ] Приложение обновляет `cache.json` если текущая дата больше соотв. дате в файле;
- [ ] Приложение перехватывает ошибки чтения из файла `сache.json`;
- [ ] Приложение правильно производит двойную конвертацию валют (`XXX -> UAH -> YYY`);
- [ ] Если валютная пара не найдена, то приложение сообщает об ошибке и выходит с `ReturnCode` равным `Error`;
- [ ] Убедится, что для каждый класс/интерфейс находится в отдельном .cs файле;
- [ ] Убедится, что классы/интерфейсы/перечисления/свойства названы в PascalCase, а имена полей/аргументов/переменных - в camelCase.
