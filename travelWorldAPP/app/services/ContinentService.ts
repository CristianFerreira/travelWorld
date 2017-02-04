
/// <reference path="../configs/_all.ts" />


module Travel_World {

    export class ContinentService extends AppServiceBase implements IAppService{

        public getById(id: number): any {
            return super.getByIdFromUrl(appConfig.serviceUrls().continent.listAll, id);
        }

        public listAll(): any {
            return super.listAllFromUrl(appConfig.serviceUrls().continent.listAll);
        }

        public deleteContinent(id: number): any{
              return super.removeByUrl(appConfig.serviceUrls().continent.deleteContinent, id);
        }

        public deleteContinentAlot(continents :Array<Continent>): any{
              return super.postFromUrl(appConfig.serviceUrls().continent.deleteAlotContinent, continents);
        }

        public editContinent(continent: Continent): any{
          
              return super.updateByUrl(appConfig.serviceUrls().continent.editContinent, continent);
         }
        

         public saveCategory(continent: Continent): any{
          
              return super.postFromUrl(appConfig.serviceUrls().continent.saveContinent, continent);
         }

    }

    angular.module(appConfig.appName).service("ContinentService", ContinentService);
}