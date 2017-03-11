/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalDeletePostController {

        static $inject = ['PostService', '$mdDialog'];

        private postService: PostService;
        public $mdDialog: any;

        

        constructor(postService: PostService, $mdDialog: any) {
            this.postService = postService;         
            this.$mdDialog = $mdDialog;  
        }



        public deletePost() :void {
            this.$mdDialog.hide({message: 'deletar'});  
        }

        public cancel() :void {
            this.$mdDialog.cancel();
        }

    }

    angular.module(appConfig.appName).controller('ModalDeletePostController', ModalDeletePostController);
    
}
