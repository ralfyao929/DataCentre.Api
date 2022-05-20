# DataCentre.Api
###### 這個專案使用Micorsoft Entity Framework，專用於果核帳務系統的後端帳務資料處理
###### 這個專案包含的子專案與說明，分別如下：
- **_DataCentre.Api_**
  - 果核雲端帳務WebApi主要網站專案
- **_DataCentre.Api.Entity_**
  - WebApi所需用到的Model類別專案，此專案輸出檔案類型為DLL，提供給主要WebApi呼叫使用。
- **_DataCentre.Api.Repository_**
  - Model類別的存放庫，透過此類別存放庫，WebApi可以對資料庫進行查詢與操作
- **_DataCentre.Api.Contracts_**
  - 負責與資料庫溝通並執行查詢與資料操作，在此專案中會使用到EntityFramework
- **_DataCentre.Api.LoggerService_**
  - 該解決方案專用的Log服務
- **_DataCentre.Api.Utility_**
  - 公用類別專案
> # 如何增加一個WebApi
1. 建立Model：
    - 在 **_DataCentre.Api.Entity_** 專案下，建立與資料表溝通的類別
    - ![2022-05-10_08-55-21](https://user-images.githubusercontent.com/70353579/167521621-855fbafc-9721-4764-abcd-52717a576900.png)
    - 在 **_DataCentre.Api.Entity_** 專案下 ，找出RepositoryContext類別，並在該類別程式碼內加上上面所建類別的DbSet物件：
    - ![2022-05-10_08-57-32](https://user-images.githubusercontent.com/70353579/167521856-85f9f9fb-7461-4df1-b3e8-0ba5ecff0d38.png)
2. 建立Contract：
    - 在 **_DataCentre.Api.Contracts_** 專案下，建立I[ModelName]DataRepository介面，該介面必須實作IRepositoryBase<[ModelName]>：
    - ![2022-05-10_09-10-39](https://user-images.githubusercontent.com/70353579/167522794-ee3f5af5-409d-4481-9c00-152ef55abfaa.png)
4. 建立Repository：
    - 在 **_DataCentre.Api.Repository_** 專案下，建立[ModelName]Repository.cs，該類別必須繼承RepositoryBase<[ModelName]>、實作上面所建立的IRepositoryBase<[ModelName]>介面：
    - ![2022-05-10_09-13-22](https://user-images.githubusercontent.com/70353579/167523149-c38b5120-dcc3-4ab7-aace-8ffbb505057f.png)
    - 回到 **_DataCentre.Api.Contracts_** 專案，在IRepositoryWrapper介面內，增加一個上面所建立的I<[ModelName]>DataRepository成員：
    - ![2022-05-10_09-17-49](https://user-images.githubusercontent.com/70353579/167523672-309d3406-ecb7-40e5-b8c6-8221063d0a0f.png)
5. 之後就可以在Controller內使用該Repository函式：
    - ![2022-05-10_09-21-34](https://user-images.githubusercontent.com/70353579/167523961-792d6ec4-40ce-4311-b215-c70f76d65898.png)
6. 建立Controller：
    - 在 **_DataCentre.Api_** 專案下，右鍵點選Controller-->加入-->控制器：
    - ![2022-05-20_11-22-11](https://user-images.githubusercontent.com/70353579/169444150-5e9c1e74-49ea-4645-a738-5def74d3aa04.png)
    - 在Controller程式碼內，增加ILoggerManager與IRepositoryWrapper成員，並新增建構子，帶入兩成員參數，並初始兩成員的物件：
    - ![2022-05-20_11-24-37](https://user-images.githubusercontent.com/70353579/169444412-45cd9eb0-d788-47b4-b0ad-a378d3610870.png)
    - 善用這兩個物件，對於建構Controller會有很大的幫助：
    - ![2022-05-20_11-27-39](https://user-images.githubusercontent.com/70353579/169444686-2065cbcf-86ce-4303-a708-cc3a4a518d45.png)
