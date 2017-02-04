/// <reference path="../../configs/_all.ts" />
module Travel_World {
    export class ModalCreateContinentController {

        static $inject = ['ContinentService', 'toastr', '$mdDialog'];

        public continentService: ContinentService;
        public toastr: Toastr;
        public mdDialog: any;
        public continent: Continent;

        constructor(continentService: ContinentService, toastr: Toastr, mdDialog: any) {
            this.continentService = continentService;
            this.toastr = toastr;
            this.mdDialog = mdDialog;
            this.continent = new Continent();
        }

        public createContinent() :void {          
          this.continentService.saveCategory(this.continent)
                .then((data) => {                 
                    this.mdDialog.cancel();
                    this.toastr.success("Continente criado com sucesso!");                          
                })
                .catch((response) => {
                    this.toastr.error('Continente não pode ser criada!');
                })   
        }

        public cancel(): void {
            console.log("cancel");
            this.mdDialog.cancel();
        }
    }

    angular.module(appConfig.appName).controller('ModalCreateContinentController', ModalCreateContinentController);
}