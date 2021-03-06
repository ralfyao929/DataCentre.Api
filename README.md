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
    - 注意要補上[Table("")]指示：
    - ![2022-06-08_11-50-21](https://user-images.githubusercontent.com/70353579/172527746-fc9ca953-b59e-4463-be51-15f3ee73feaa.png)
    - Model新增的Class所加上得[Table()]與[Column()]的tag，可以對應到資料庫真正的Table與Column，即便類別的成員與資料庫實際名稱不相符
    - ![2022-06-10_15-49-40](https://user-images.githubusercontent.com/70353579/173017580-c856c359-16b7-459c-9e43-481726e79f88.png)
2. 建立Contract：
    - 在 **_DataCentre.Api.Contracts_** 專案下，建立I[ModelName]DataRepository介面，該介面必須實作IRepositoryBase<[ModelName]>：
    - ![2022-05-10_09-10-39](https://user-images.githubusercontent.com/70353579/167522794-ee3f5af5-409d-4481-9c00-152ef55abfaa.png)
4. 建立Repository：
    - 在 **_DataCentre.Api.Repository_** 專案下，建立[ModelName]Repository.cs，該類別必須繼承RepositoryBase<[ModelName]>、實作上面所建立的I<[ModelName]>Repository介面：
    - ![2022-05-10_09-13-22](https://user-images.githubusercontent.com/70353579/167523149-c38b5120-dcc3-4ab7-aace-8ffbb505057f.png)
    - 回到 **_DataCentre.Api.Contracts_** 專案，在IRepositoryWrapper介面內，增加一個上面所建立的I<[ModelName]>DataRepository成員：
    - ![2022-05-10_09-17-49](https://user-images.githubusercontent.com/70353579/167523672-309d3406-ecb7-40e5-b8c6-8221063d0a0f.png)
    - 在RepositoryWrapper內加上 I<ModelName>Repository的成員，與實作在上面所IRepositoryWrapper介面新增的I<[ModelName]>DataRepository成員，的get函式：
    - ![2022-06-08_11-32-59](https://user-images.githubusercontent.com/70353579/172526078-e28bf627-8418-451c-ba54-b0583eaf047a.png)
5. 之後就可以在Controller內使用該Repository函式：
    - ![2022-05-10_09-21-34](https://user-images.githubusercontent.com/70353579/167523961-792d6ec4-40ce-4311-b215-c70f76d65898.png)
6. 建立Controller：
    - 在 **_DataCentre.Api_** 專案下，右鍵點選Controller-->加入-->控制器：
    - ![2022-05-20_11-22-11](https://user-images.githubusercontent.com/70353579/169444150-5e9c1e74-49ea-4645-a738-5def74d3aa04.png)
    - 程式碼要繼承BaseController，並且呼叫父類別的建構子：
    - ![2022-06-07_16-28-56](https://user-images.githubusercontent.com/70353579/172334257-7454e4d1-e52b-4ea6-984f-dc6c8a625e9e.png)
    - 善用繼承自父類別的這兩個物件，對於建構Controller會有很大的幫助：
    - ![2022-05-20_11-27-39](https://user-images.githubusercontent.com/70353579/169444686-2065cbcf-86ce-4303-a708-cc3a4a518d45.png)
> # 注意要點
1. 如果一個Table有多個Key，如以下的Table - UserPrivilege：
    - ![2022-06-07_09-19-33](https://user-images.githubusercontent.com/70353579/172275518-95602843-6f65-4bf0-89ac-5431770de6b8.png)
    - 在 **_RepositoryContext_** 內，就必須在OnModelCreateing使用HasKey()來指定該Table的Key：
    - ![2022-06-07_09-18-51](https://user-images.githubusercontent.com/70353579/172275681-7f722fe4-e810-49b8-918d-74358ab34008.png)
2. 如果不想套用以上的架構存取單個Table資料，想自行寫較複雜的SQL，亦可透過以下例子進行查詢：
    - ![2022-06-08_08-26-14](https://user-images.githubusercontent.com/70353579/172505945-6ca83448-029d-401a-82a9-9155d806f155.png)
3. 如果有新增修改刪除資料，最後一定要呼叫該Model的Repository的Save()：
    - ![2022-06-13_11-43-06](https://user-images.githubusercontent.com/70353579/173275591-46175507-a2ae-4c18-8f3d-cf53517839ed.png)


