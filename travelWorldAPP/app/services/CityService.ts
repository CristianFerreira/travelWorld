
/// <reference path="../configs/_all.ts" />


module Travel_World {

    export class CityService extends AppServiceBase implements IAppService{

        public getById(id: number): any {
            return super.getByIdFromUrl(appConfig.serviceUrls().city.listAll, id);
        }

        public listAll(): any {
            return super.listAllFromUrl(appConfig.serviceUrls().city.listAll);
        }

        public deleteCity(id: number): any{
              return super.removeByUrl(appConfig.serviceUrls().city.deleteCity, id);
        }

        public deleteCityAlot(cities :Array<City>): any{
              return super.postFromUrl(appConfig.serviceUrls().city.deleteAlotCity, cities);
        }

        public editCity(city: City): any{
          
              return super.updateByUrl(appConfig.serviceUrls().city.editCity, city);
         }
        

         public saveCity(city: City): any{
          
              return super.postFromUrl(appConfig.serviceUrls().city.saveCity, city);
         }

    }

    angular.module(appConfig.appName).service("CityService", CityService);
}