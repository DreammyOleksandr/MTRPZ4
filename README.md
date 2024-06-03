![MasterHead](https://upload.wikimedia.org/wikipedia/commons/2/20/Matrix_Digital_rain_banner.gif)

# 🏹 MaToSD (Lab 4)

Цей застосунок розроблений для обробки результатів опитування та їх візуалізації.

- [Павлик Гліб](https://github.com/HlibPavlyk)
- [Горчинський Назарій](https://github.com/Nazg0r)
- [Бондаренко Олександр](https://github.com/DreammyOleksandr)

## 👷 Як зібрати і запустити проєкт

Коли знаходитесь у корені репозиторію, то пропишіть
``` Linux
cd src/MTRPZ4.UI
```
щоб перейти до репозиторію самої програми

Щоб зібрати проєкт:

```
dotnet build
```

І запустити:

```
dotnet run --urls https://localhost:5000
```

де в параметрі `--urls` можете вказати бажаний порт

## 👷 Як запустити тести

Коли знаходитесь у корені репозиторію, то пропишіть
```
cd tests/MTRPZ4.UnitTests
```
щоб перейти до репозиторію тестів

І запустити:

```
dotnet test
```
