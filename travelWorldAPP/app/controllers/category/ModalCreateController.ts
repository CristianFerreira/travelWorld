/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalCreateController {

        static $inject = ['CategoryService', 'toastr', '$mdDialog'];

        public categoryService: CategoryService;
        public toastr: Toastr;
        public mdDialog: any;
        public category: Category;

        constructor(categoryService: CategoryService, toastr: Toastr, mdDialog: any) {
            this.categoryService = categoryService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.category = new Category();
        }

        public createCategory() :void {          
          this.categoryService.saveCategory(this.category)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Categoria criada com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Categoria não pode ser criada!');
                })   
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalCreateController', ModalCreateController);
}