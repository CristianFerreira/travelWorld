
/// <reference path="../configs/_all.ts" />


module Travel_World {

    export class PostService extends AppServiceBase implements IAppService{

        public getById(id: number): any {
            return super.getByIdFromUrl(appConfig.serviceUrls().post.getById, id);
        }

        public getByCategoria(categoria: any): any {
            return super.getFromUrl(appConfig.serviceUrls().post.getByCategoria, categoria);
        }

         public getByCity(city: any): any {
            return super.getFromUrl(appConfig.serviceUrls().post.getByCity, city);
        }

        public listAll(): any {
            return super.listAllFromUrl(appConfig.serviceUrls().post.listAll);
        }

        public deletePost(id: number): any{
              return super.removeByUrl(appConfig.serviceUrls().post.deletePost, id);
        }

        public deletePostAlot(posts :Array<Post>): any{
              return super.postFromUrl(appConfig.serviceUrls().post.deleteAlotPost, posts);
        }

        public editPost(post: Post): any{
          
              return super.updateByUrl(appConfig.serviceUrls().post.editPost, post);
         }
        

         public savePost(post: Post): any{
          
              return super.postFromUrl(appConfig.serviceUrls().post.savePost, post);
         }

    }

    angular.module(appConfig.appName).service("PostService", PostService);
}