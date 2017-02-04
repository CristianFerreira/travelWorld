/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalDeleteController {

        static $inject = ['CategoryService', 'toastr', '$mdDialog', 'deleteCategorys'];

        public categoryService: CategoryService;
        public toastr: Toastr;
        public mdDialog: any;
        public deleteCategorys: Array<Category>;

        constructor(categoryService: CategoryService, toastr: Toastr, mdDialog: any, deleteCategorys: Array<Category>) {
            this.categoryService = categoryService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.deleteCategorys = deleteCategorys;
        }

        public deleteCategory() :void {           
                this.categoryService.deleteCategoryAlot(this.deleteCategorys)
                .then((data) => {   
                    if(data.length > 1)                
                        this.toastr.success("Categorias excluidas com sucesso!"); 
                    else
                        this.toastr.success("Categoria excluida com sucesso!"); 

                    this.mdDialog.cancel();                                         
                })
                .catch((response) => {
                    this.toastr.error('Categoria não pode ser excluida!');
                })      
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalDeleteController', ModalDeleteController);
}