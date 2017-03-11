
/// <reference path="../configs/_all.ts" />


module Travel_World {

    export class CommentService extends AppServiceBase implements IAppService{

        public getById(id: number): any {
            return super.getByIdFromUrl(appConfig.serviceUrls().comment.getById, id);
        }

        public listAll(): any {
            return super.listAllFromUrl(appConfig.serviceUrls().comment.listAll);
        }

        public deleteComment(id: number): any{
              return super.removeByUrl(appConfig.serviceUrls().comment.deleteComment, id);
        }

        public deleteCommentAlot(comments :Array<Comment>): any{
              return super.postFromUrl(appConfig.serviceUrls().comment.deleteAlotComment, comments);
        }

        public editComment(comment: Comment): any{
          
              return super.updateByUrl(appConfig.serviceUrls().comment.editComment, comment);
         }
        

         public saveComment(comment: Comment): any{
          
              return super.postFromUrl(appConfig.serviceUrls().comment.saveComment, comment);
         }

    }

    angular.module(appConfig.appName).service("CommentService", CommentService);
}