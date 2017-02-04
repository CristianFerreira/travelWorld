/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalEditController {

        static $inject = ['CategoryService', 'toastr', '$mdDialog', 'category'];

        public categoryService: CategoryService;
        public toastr: Toastr;
        public mdDialog: any;
        public category: Category;

        constructor(categoryService: CategoryService, toastr: Toastr, mdDialog: any, category: Category) {
            this.categoryService = categoryService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.category = category;
        }

        public editCategory() :void {    
            console.log(this.category);      
          this.categoryService.editCategory(this.category)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Categoria editada com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Categoria não pode ser editada!');
                })   
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalEditController', ModalEditController);
}