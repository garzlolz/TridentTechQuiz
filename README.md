# TridentTech
## [Swagger Doc](https://app.swaggerhub.com/apis-docs/OSCAR861213/TridentTechQuiz/1)
## 1. 修改 appsettings.json 中的連線字串

修改 appsettings.json 中的連線字串 或修改 appsettings.Development.json

- 位置 `TridentTech/TridentTech/appsettings.json`

```
  "ConnectionStrings": {
    "TridentTech": "Server={Your DB Host};TrustServerCertificate=True;Database=TridentTech;User ID={Acccount Id};Password={Account Password};"
  }
```

## 2. 加入 DB 結構

1. 執行 Trident.sql，位置 ` TridentTech/Trident.sql`

2. 或使用 Code First 指令

```
Nuget> Update-Dabase
```

## 3.先執行 TridentTech.sln 

1. 啟動TridentTech.sln並執行

- ![error](https://i.imgur.com/3MskcB2.png)

2. 透過登入取得BearerToken執行相對應的API
- ![error](https://i.imgur.com/WSf0Z3h.png)

## 4.再TridentTechTest.sln

1. 啟動Test.sln並開啟測試總管執行測試 
- ![error](https://i.imgur.com/Dgc0MI1.png)

2. 確認所有測試皆成功
- ![error](https://i.imgur.com/OayATW1.png)

