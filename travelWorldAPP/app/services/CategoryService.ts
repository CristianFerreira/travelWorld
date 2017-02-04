
/// <reference path="../configs/_all.ts" />


module Travel_World {

    export class CategoryService extends AppServiceBase implements IAppService{

        public getById(id: number): any {
            return super.getByIdFromUrl(appConfig.serviceUrls().category.listAll, id);
        }

        public listAll(): any {
            return super.listAllFromUrl(appConfig.serviceUrls().category.listAll);
        }

        public deleteCategory(id: number): any{
              return super.removeByUrl(appConfig.serviceUrls().category.deleteCategory, id);
        }

         public deleteCategoryAlot(categories :Array<Category>): any{
              return super.postFromUrl(appConfig.serviceUrls().category.deleteAlotCategories, categories);
        }


        public editCategory(category: Category): any{
          
              return super.updateByUrl(appConfig.serviceUrls().category.editCategory, category);
         }
        

         public saveCategory(category: Category): any{
          
              return super.postFromUrl(appConfig.serviceUrls().category.saveCategory, category);
         }

    }

    angular.module(appConfig.appName).service("CategoryService", CategoryService);
}