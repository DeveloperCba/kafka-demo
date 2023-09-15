﻿namespace ConsoleProducer.Models
{
    public class OmniProcessDto
    {
        public string IdSistema { get; set; }
        public string SkProcesso { get; set; }
        public string NumeroUnico { get; set; }
    }

    public class OmniProcess
    {
        public string SkTempo { get; set; }
        public string Data { get; set; }
        public string DataPorExtenso { get; set; }
        public string Quinzena { get; set; }
        public string Bimestre { get; set; }
        public string Trimestre { get; set; }
        public string Semestre { get; set; }
        public string AnoCorrente { get; set; }
        public string SkProcesso { get; set; }
        public string NumeroUnico { get; set; }
        public string Protocolo { get; set; }
        public string Ano { get; set; }
        public string IdSistema { get; set; }
        public string NomeSistema { get; set; }
        public string SkTipoTramitacao { get; set; }
        public string EletronicoOuFisico { get; set; }
        public string ValorCausa { get; set; }
        public string DataCalculo { get; set; }
        public string CabecalhoAtual { get; set; }
        public string ExisteParteOptantePorJusticaGratuita { get; set; }
        public string NumeroUnicoFormatado { get; set; }
        public string PrioridadePeso { get; set; }
        public string DataProtocolo { get; set; }
        public string SkEsferaAtual { get; set; }
        public string NomeEsferaAtual { get; set; }
        public string SkEsfera { get; set; }
        public string NomeEsfera { get; set; }
        public string SkClasseAtual { get; set; }
        public string ClasseAtual { get; set; }
        public string SkClasse { get; set; }
        public string CodigoClasse { get; set; }
        public string NomeClasse { get; set; }
        public string SkFaseAtual { get; set; }
        public string FaseAtual { get; set; }
        public string SkFase { get; set; }
        public string DescricaoFase { get; set; }
        public string GrupoFase { get; set; }
        public string SkEstruturaJudiciaria { get; set; }
        public string NomeEstruturaJudiciaria { get; set; }
        public string NomeJurisdicao { get; set; }
        public string NomeEntrancia { get; set; }
        public string NomeTipoReparticao { get; set; }
        public string SkAssuntoPrincipal { get; set; }
        public string SkTipoEvento { get; set; }
        public string NomeTipoEvento { get; set; }
        public string SkComplementoTabelado { get; set; }
        public string NomeComplementoTabelado { get; set; }
        public string SkNivelVisibilidade { get; set; }
        public string NivelVisibilidade { get; set; }
        public string IdEvento { get; set; }
        public string IdEntidadeNegocio { get; set; }
        public string SkOrgaoJulgador { get; set; }
        public string OrgaoJulgadorNomeAbreviado { get; set; }
        public string CnOCrim2 { get; set; }
        public string CnONCrim2 { get; set; }
        public string CnRCrim2 { get; set; }
        public string CnRNCrim2 { get; set; }
        public string CnCCrim1 { get; set; }
        public string CnCNCrim1 { get; set; }
        public string CnElet1 { get; set; }
        public string CnExtFisc1 { get; set; }
        public string CnExtNFisc1 { get; set; }
        public string ExeJudCrimNPL1 { get; set; }
        public string ExeJudCrimPL1 { get; set; }
        public string ExeJudNCrim1 { get; set; }
        public string CnEletTR { get; set; }
        public string CnOCrimTR { get; set; }
        public string CnONCrimTR { get; set; }
        public string CnElet2 { get; set; }
        public string CnRCrimTR { get; set; }
        public string CnRNCrimTR { get; set; }
        public string CnCCrimJE { get; set; }
        public string CnCNCrimJe { get; set; }
        public string CnEletJE { get; set; }
        public string CnExtJE { get; set; }
        public string ExeJudCrimNPLJE { get; set; }
        public string ExeJudNCrimJE { get; set; }
        public string TBaixCrim2 { get; set; }
        public string TBaixNCrim2 { get; set; }
        public string TBaixCCrim1 { get; set; }
        public string TBaixCNCrim1 { get; set; }
        public string TBaixExtFisc1 { get; set; }
        public string TBaixExtNFisc1 { get; set; }
        public string TBaixJudCrimNPL1 { get; set; }
        public string TBaixJudCrimPL1 { get; set; }
        public string TBaixJudNCrim1 { get; set; }
        public string TBaixCrimTR { get; set; }
        public string TBaixNCrimTR { get; set; }
        public string TBaixCCrimJE { get; set; }
        public string TBaixCNCrimJE { get; set; }
        public string TBaixExtJE { get; set; }
        public string TBaixJudCrimNPLJE { get; set; }
        public string TBaixJudNCrimJE { get; set; }
        public string DecCrim2 { get; set; }
        public string DecH2 { get; set; }
        public string DecNCrim2 { get; set; }
        public string SentCCrim1 { get; set; }
        public string SentCH1 { get; set; }
        public string SentCNCrim1 { get; set; }
        public string SentExH1 { get; set; }
        public string SentExtFisc1 { get; set; }
        public string SentExtNFisc1 { get; set; }
        public string SentJudCrimNPL1 { get; set; }
        public string SentJudCrimPL1 { get; set; }
        public string SentJudNCrim1 { get; set; }
        public string DecCrimTR { get; set; }
        public string DecHTR { get; set; }
        public string DecNCrimTR { get; set; }
        public string SentCCrimJE { get; set; }
        public string SentCHJE { get; set; }
        public string SentCNCrimJE { get; set; }
        public string SentExHJE { get; set; }
        public string SentExtJE { get; set; }
        public string SentJudCrimNPLJE { get; set; }
        public string SentJudNCrimJE { get; set; }
        public string IncExJFisc1 { get; set; }
        public string IncExJNFisc1 { get; set; }
        public string IncExJJE { get; set; }
        public string RInt2 { get; set; }
        public string RintJ2 { get; set; }
        public string RIntC1 { get; set; }
        public string RIntCJ1 { get; set; }
        public string RintJTR { get; set; }
        public string RIntTR { get; set; }
        public string RIntCJE { get; set; }
        public string RIntCJJe { get; set; }
        public string Apublic2 { get; set; }
        public string RSup2 { get; set; }
        public string DeRExt1 { get; set; }
        public string RSup1 { get; set; }
        public string DeImpJE { get; set; }
        public string DeRExtJE { get; set; }
        public string ISupJE { get; set; }
        public string RSupJE { get; set; }
        public string ArqNCrim { get; set; }
        public string ArqNCrimJG { get; set; }
        public string ReatCrim2 { get; set; }
        public string ReatNCrim2 { get; set; }
        public string ReatCCrim1 { get; set; }
        public string ReatCNCrim1 { get; set; }
        public string ReatExtFisc1 { get; set; }
        public string ReatExtNFisc1 { get; set; }
        public string ExeJudRCrimNPL1 { get; set; }
        public string ExeJudRCrimPL1 { get; set; }
        public string ExeJudRNcrim1 { get; set; }
        public string ReatCrimTR { get; set; }
        public string ReatNCrimTR { get; set; }
        public string ReatCCrimJE { get; set; }
        public string ReatCNCrimJE { get; set; }
        public string ReatExtJE { get; set; }
        public string ExeJudRCrimNPLJE { get; set; }
        public string ExeJudRNCrimJE { get; set; }
        public string CartaN2 { get; set; }
        public string CartaN1 { get; set; }
        public string CartaNTR { get; set; }
        public string CartaNJE { get; set; }
        public string CartaD2 { get; set; }
        public string CartaD1 { get; set; }
        public string CartaDTR { get; set; }
        public string CartaDJE { get; set; }
        public string InqN2 { get; set; }
        public string InqN1 { get; set; }
        public string TeCNJE { get; set; }
        public string InqArq2 { get; set; }
        public string InqArq1 { get; set; }
        public string TeCArqJE { get; set; }
        public string PRedCrim2 { get; set; }
        public string PRedNCrim2 { get; set; }
        public string PRedCCrim1 { get; set; }
        public string PRedCNCrim1 { get; set; }
        public string PRedExtFisc1 { get; set; }
        public string PRedExtNFisc1 { get; set; }
        public string PRedCrimTR { get; set; }
        public string PRedNCrimTR { get; set; }
        public string PRedCNCrimJE { get; set; }
        public string PRedCCrimJE { get; set; }
        public string PRedExJE { get; set; }
        public string SentCCMCrim1 { get; set; }
        public string SentCSMCrim1 { get; set; }
        public string SentCCMNCrim1 { get; set; }
        public string SentCSMNCrim1 { get; set; }
        public string SentCCMCrimJE { get; set; }
        public string SentCSMCrimJE { get; set; }
        public string SentCCMNCrimJE { get; set; }
        public string SentCSMNCrimJE { get; set; }
        public string QAPR { get; set; }
        public string QAIR { get; set; }
        public string QDP { get; set; }
        public string QMP { get; set; }
        public string QJR { get; set; }
        public string CnCVD { get; set; }
        public string TbaixCVD { get; set; }
        public string SentCCMCVD { get; set; }
        public string SentCSMCVD { get; set; }
        public string ExeJudCrimVD1 { get; set; }
        public string TbaixJudCrimVD1 { get; set; }
        public string SentJudCrimVD1 { get; set; }
        public string InqArqVD1 { get; set; }
        public string InqCPVD1 { get; set; }
        public string InqNVD1 { get; set; }
        public string CNCFEM { get; set; }
        public string TbaixCFEM { get; set; }
        public string SentCCMCFEM { get; set; }
        public string SentCSMCFEM { get; set; }
        public string ExeJudCrimFEM1 { get; set; }
        public string TbaixJudCrimFEM1 { get; set; }
        public string SentJudCrimFEM1 { get; set; }
        public string InqArqFEM1 { get; set; }
        public string InqCPFEM1 { get; set; }
        public string InqNFEM1 { get; set; }
        public string QDIntP { get; set; }
        public string PJDistribuido { get; set; }
        public string PJRedistribuido { get; set; }
        public string PJBaixado { get; set; }
        public string PJJulgamento { get; set; }
        public string Dias { get; set; }
        public string TpTot { get; set; }
        public string TpDec2 { get; set; }
        public string TpSentC1 { get; set; }
        public string TpSentEx1 { get; set; }
        public string TpDecTR { get; set; }
        public string TpSentCJE { get; set; }
        public string TpSentExJE { get; set; }
        public string TpBaixCrim2 { get; set; }
        public string TpBaixNCrim2 { get; set; }
        public string TpBaixCCrim1 { get; set; }
        public string TpBaixCNCrim1 { get; set; }
        public string TpBaixExtFisc1 { get; set; }
        public string TpBaixExtNFisc1 { get; set; }
        public string TpBaixJudCrimPL1 { get; set; }
        public string TpBaixJudCrimNPL1 { get; set; }
        public string TpBaixJudNCrim1 { get; set; }
        public string TpBaixCrimTR { get; set; }
        public string TpBaixNCrimTR { get; set; }
        public string TpBaixCCrimJE { get; set; }
        public string TpBaixCNCrimJE { get; set; }
        public string TpBaixExtJE { get; set; }
        public string TpBaixJudCrimNPlJE { get; set; }
        public string TpBaixJudNCrimJE { get; set; }
        public string AudConc2 { get; set; }
        public string AudNConc2 { get; set; }
        public string DecDC2 { get; set; }
        public string DecHDC2 { get; set; }
        public string DecInt2 { get; set; }
        public string PRedRCrim2 { get; set; }
        public string PRedRNCrim2 { get; set; }
        public string ProcInvArq2 { get; set; }
        public string ProcInvN2 { get; set; }
        public string VotoRCrim2 { get; set; }
        public string VotoRNCrim2 { get; set; }
        public string VPfGCrim2 { get; set; }
        public string VPfGNCrim2 { get; set; }
        public string VPnGCrim2 { get; set; }
        public string VPnGNCrim2 { get; set; }
        public string AudConcTR { get; set; }
        public string AudNConcTR { get; set; }
        public string DecDCTR { get; set; }
        public string DecHDCTR { get; set; }
        public string DecIntTR { get; set; }
        public string PRedRCrimTR { get; set; }
        public string PRedRNCrimTR { get; set; }
        public string VotoRCrimTR { get; set; }
        public string VotoRNCrimTR { get; set; }
        public string VPfGCrimTR { get; set; }
        public string VPfGNCrimTR { get; set; }
        public string VPnGCrimTR { get; set; }
        public string VPnGNCrimTR { get; set; }
        public string AudConc1 { get; set; }
        public string AudNConc1 { get; set; }
        public string DecInt1 { get; set; }
        public string DecJudCrim1 { get; set; }
        public string PRedRCCrim1 { get; set; }
        public string PRedRCNCrim1 { get; set; }
        public string PRedRExtFisc1 { get; set; }
        public string PRedRExtNFisc1 { get; set; }
        public string ProcInvArq1 { get; set; }
        public string ProcInvN1 { get; set; }
        public string SentDC1 { get; set; }
        public string SentHDC1 { get; set; }
        public string AudConcJE { get; set; }
        public string AudNConcJE { get; set; }
        public string DecIntJE { get; set; }
        public string DecJudCrimJE { get; set; }
        public string PRedCRecNCrimJE { get; set; }
        public string PRedRCCrimJE { get; set; }
        public string PRedRExJE { get; set; }
        public string ProcInvArqJE { get; set; }
        public string ProcInvNJE { get; set; }
        public string SentDCJE { get; set; }
        public string SentHDCJE { get; set; }
        public string Despacho { get; set; }
        public string ImpactoNaRes76 { get; set; }
        public string IdEntidadeNegocioGeradora { get; set; }
        public string PRedRCNCrimJE { get; set; }
        public string SkTipoReparticao { get; set; }
        public string SkGabinete { get; set; }
        public string CnOCrim2_cejusc { get; set; }
        public string CnONCrim2_cejusc { get; set; }
        public string CnRCrim2_cejusc { get; set; }
        public string CnRNCrim2_cejusc { get; set; }
        public string CnCCrim1_cejusc { get; set; }
        public string CnCNCrim1_cejusc { get; set; }
        public string CnOCrimTR_cejusc { get; set; }
        public string CnONCrimTR_cejusc { get; set; }
        public string CnRCrimTR_cejusc { get; set; }
        public string CnRNCrimTR_cejusc { get; set; }
        public string CnCCrimJE_cejusc { get; set; }
        public string CnCNCrimJE_cejusc { get; set; }
        public string CnRPP_cejusc { get; set; }
        public string TBaixOCrim2_cejusc { get; set; }
        public string TBaixONCrim2_cejusc { get; set; }
        public string TBaixRCrim2_cejusc { get; set; }
        public string TBaixRNCrim2_cejusc { get; set; }
        public string TBaixCCrim1_cejusc { get; set; }
        public string TBaixCNCrim1_cejusc { get; set; }
        public string TBaixOCrimTR_cejusc { get; set; }
        public string TBaixONCrimTR_cejusc { get; set; }
        public string TBaixRCrimTR_cejusc { get; set; }
        public string TBaixRNCrimTR_cejusc { get; set; }
        public string TBaixCCrimJE_cejusc { get; set; }
        public string TBaixCNCrimJE_cejusc { get; set; }
        public string TBaixRPP_cejusc { get; set; }
        public string AudConcRealOCrim2_cejusc { get; set; }
        public string AudMedRealOCrim2_cejusc { get; set; }
        public string AudConcRealONCrim2_cejusc { get; set; }
        public string AudMedRealONCrim2_cejusc { get; set; }
        public string AudArt334RealONCrim2_cejusc { get; set; }
        public string AudConcRealRCrim2_cejusc { get; set; }
        public string AudMedRealRCrim2_cejusc { get; set; }
        public string AudConcRealRNCrim2_cejusc { get; set; }
        public string AudMedRealRNCrim2_cejusc { get; set; }
        public string AudConcRealCCrim1_cejusc { get; set; }
        public string AudMedRealCCrim1_cejusc { get; set; }
        public string AudConcRealCNCrim1_cejusc { get; set; }
        public string AudMedRealCNCrim1_cejusc { get; set; }
        public string AudArt334RealCNCrim1_cejusc { get; set; }
        public string AudConcRealOCrimTR_cejusc { get; set; }
        public string AudMedRealOCrimTR_cejusc { get; set; }
        public string AudConcRealONCrimTR_cejusc { get; set; }
        public string AudMedRealONCrimTR_cejusc { get; set; }
        public string AudArt334RealONCrimTR_cejusc { get; set; }
        public string AudConcRealCCrimJE_cejusc { get; set; }
        public string AudMedRealCCrimJE_cejusc { get; set; }
        public string AudConcRealCNCrimJE_cejusc { get; set; }
        public string AudMedRealCNCrimJE_cejusc { get; set; }
        public string AudConcRealRPP_cejusc { get; set; }
        public string AudMedRealRPP_cejusc { get; set; }
        public string AcordosRPP_cejusc { get; set; }
        public string ImpactoNaCejusc { get; set; }
        public string SentCH1_cejusc { get; set; }
        public string SentCHJE_cejusc { get; set; }
        public string DecH2_cejusc { get; set; }
        public string DecHTR_cejusc { get; set; }
        public string SkTipoEventoProprio { get; set; }
        public string DataHora { get; set; }
        public string AudConcPRE_Nupemec { get; set; }
        public string SentPre_Nupemec { get; set; }
        public string SentCHNcrim1_Nupemec { get; set; }
        public string SentCHNcrimJE_Nupemec { get; set; }
        public string DecHNcrim2_Nupemec { get; set; }
        public string DecHNcrimTR_Nupemec { get; set; }
        public string AudConc1_Nupemec { get; set; }
        public string AudConcJE_Nupemec { get; set; }
        public string AudConcTR_Nupemec { get; set; }
        public string AudConc2_Nupemec { get; set; }
        public string CnPre_Nupemec { get; set; }
        public string SentHDCJE_Nupemec { get; set; }
        public string SentHDC1_Nupemec { get; set; }
    }
}
