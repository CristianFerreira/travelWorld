
/// <reference path="../../configs/_all.ts" />
module KTAX_SOS_Workflow {
    export class ModalConfiguracaoController {

        static $inject = ['$uibModalInstance', 'WorkflowService', 'workflowTipoTarefaTela', 'toastr'];
        
        private $uibModalInstance: IModalServiceInstance;
        private workflowService: WorkflowService;
        public workflowTipoTarefaTela: Array<WorkflowTipoTarefaTela>;        
        public configuracao: WorkflowConfiguracao;
        public toastr: Toastr;
        public valor: WorkflowConfiguracaoValor;
       
        constructor( $uibModalInstance: IModalServiceInstance, 
                    workflowService: WorkflowService,
                    workflowTipoTarefaTela: Array<WorkflowTipoTarefaTela>,
                    toastr :Toastr ) {            
            this.$uibModalInstance = $uibModalInstance; 
            this.workflowService = workflowService;           
            this.workflowTipoTarefaTela = workflowTipoTarefaTela;
            this.toastr = toastr;
            this.criaConfiguracoes (this.workflowTipoTarefaTela);
        }

        public criaConfiguracoes (workflowTipoTarefaTela: Array<WorkflowTipoTarefaTela>) {
            this.configuracao = new WorkflowConfiguracao();
            this.configuracao.idTipoTarefa = workflowTipoTarefaTela[0].idTipoTarefa; 

            workflowTipoTarefaTela.forEach((w) => {
                this.valor = new WorkflowConfiguracaoValor();
                this.valor.idTipoTarefaTela = w.idTipoTarefaTela;
                this.valor.tipoTarefaTela = w;
                this.configuracao.addValor(this.valor);
            });
        }

        public salvaConfiguracao (){        
           this.workflowService.salvarConfiguracao(this.configuracao)
             .then((response) => {
                   this.toastr.success("Configuração salva com sucesso!");
                   this.$uibModalInstance.close(this.configuracao);
             })
             .catch((response) => {
                   this.toastr.error("Configuração não foi salva!", "Erro");
             });
        }

        public cancel(): void {
            this.$uibModalInstance.dismiss('cancel');
        }          
    }

    angular.module(appConfig.appName).controller('ModalConfiguracaoController', ModalConfiguracaoController);
}