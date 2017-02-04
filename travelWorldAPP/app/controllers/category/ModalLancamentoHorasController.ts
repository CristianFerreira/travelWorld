
/// <reference path="../../configs/_all.ts" />
module KTAX_SOS_Workflow {
    export class ModalLancamentoHorasController {

        static $inject = ['$uibModalInstance', 'workflow', 'SosTarefarealizadoService', 'toastr'];

        private $uibModalInstance: IModalServiceInstance;
        private workflow: Workflow;
        private sosTarefarealizadoService: SosTarefarealizadoService;
        public toastr: Toastr;
        
        public horasEstimadas: HoraModel;
        public horasRealizadas: HoraModel;
        public horasFaltantes: HoraModel;
        public horasRealizadasTemp: HoraModel;
        public horasLancamento: Date;

        constructor($uibModalInstance: IModalServiceInstance, 
                        workflow: Workflow, 
                        sosTarefarealizadoService: SosTarefarealizadoService, 
                        toastr: Toastr) {

            this.$uibModalInstance = $uibModalInstance;
            this.workflow = workflow;
            this.sosTarefarealizadoService = sosTarefarealizadoService;
            this.toastr = toastr;

            this.carregarHoras(this.workflow);
        }

        public carregarHoras(workflow: Workflow) : void{
            var horas = workflow.horas.split("~");

            this.horasEstimadas = new HoraModel(horas[0]);
            this.horasRealizadas = new HoraModel(horas[1]);
            this.horasFaltantes = new HoraModel(horas[2]);
            this.horasRealizadasTemp = new HoraModel(horas[1]);
            
            this.horasLancamento = new Date();
            this.horasLancamento.setHours(0);
            this.horasLancamento.setMinutes(0);
        }

        public refresh(){
            this.horasRealizadasTemp.horas = this.horasRealizadas.horas + this.horasLancamento.getHours();
            this.horasRealizadasTemp.minutos = this.horasRealizadas.minutos + this.horasLancamento.getMinutes();

            this.horasFaltantes.horas = this.horasEstimadas.horas - (this.horasRealizadas.horas + this.horasRealizadasTemp.horas);
            this.horasFaltantes.minutos = this.horasEstimadas.minutos - (this.horasRealizadas.minutos + this.horasRealizadasTemp.minutos);
        }

        public cancel(): void {
            this.$uibModalInstance.dismiss('cancel');
        }

        public save(): void {

            var horasLancamento = this.horasLancamento.getHours() + ":" + this.horasLancamento.getMinutes();

            this.sosTarefarealizadoService.lancamentoDeHoras(this.workflow.idTarefa, 
                                                                this.workflow.idSprintProjeto, 
                                                                horasLancamento)
                .then((data) => {
                    this.toastr.success("Horas lançadas", "Sucesso");
                    this.$uibModalInstance.close(this.workflow);
                })
                .catch((response) => {
                    this.toastr.error("Horas não lançadas", "Erro");
                });
        }
    }

    angular.module(appConfig.appName).controller('ModalLancamentoHorasController', ModalLancamentoHorasController);
}