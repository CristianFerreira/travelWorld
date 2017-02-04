/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalEditContinentController {

        static $inject = ['ContinentService', 'toastr', '$mdDialog', 'continent'];

        public continentService: ContinentService;
        public toastr: Toastr;
        public mdDialog: any;
        public continent: Continent;

        constructor(continentService: ContinentService, toastr: Toastr, mdDialog: any, continent: Continent) {
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.continent = continent;
        }

        public editContinent() :void {        
          this.continentService.editContinent(this.continent)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Continente editado com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Continente não pode ser editado!');
                })   
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalEditContinentController', ModalEditContinentController);
}