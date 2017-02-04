/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalDeleteContinentController {

        static $inject = ['ContinentService', 'toastr', '$mdDialog', 'deleteContinents'];

        public continentService: ContinentService;
        public toastr: Toastr;
        public mdDialog: any;
        public deleteContinents: Array<Continent>;

        constructor(continentService: ContinentService, toastr: Toastr, mdDialog: any, deleteContinents: Array<Continent>) {
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.deleteContinents = deleteContinents;
        }

        public deleteContinent() :void {   

             this.continentService.deleteContinentAlot(this.deleteContinents)
                .then((data) => {  
                    if(data.length > 1)
                        this.toastr.success("Continentes excluidos com sucesso!"); 
                    else    
                        this.toastr.success("Continente excluido com sucesso!");
             
                    this.mdDialog.cancel();                                         
                })
                .catch((response) => {
                    this.toastr.error('Continente não pode ser excluido!');
                })      
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalDeleteContinentController', ModalDeleteContinentController);
}