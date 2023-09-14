using ConsoleProducer.Data.Context;
using ConsoleProducer.Models;
using Dapper;

namespace ConsoleProducer.Data.Repository;

public class ProcessoRepository : IProcessoRepository
{
    private readonly ApplicationDbContext _context;

    public ProcessoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OmniProcess>> GetById(long processId)
    {
		var query = GetQuery();
		query += $@" AND t0.SkProcesso = {processId}";
        return await _context.Connection.QueryAsync<OmniProcess>(query);
    }

    public async Task<IEnumerable<OmniProcess>> GetByProcessNumber(string processNumber)
    {
        var query = GetQuery();
        query += $@" AND t0.NumeroUnico = {processNumber}";
        return await _context.Connection.QueryAsync<OmniProcess>(query);
    }

    private string GetQuery()
    {
        var query = $@"
							SELECT						
								 t0.SkTempo										AS SkTempo			
								,t13.Data										AS Data	 	
								,t13.DataPorExtenso								AS DataPorExtenso	 	
								,t13.Quinzena									AS Quinzena	 	
								,t13.Bimestre									AS Bimestre	 	
								,t13.Trimestre									AS Trimestre	 
								,t13.Semestre									AS Semestre		
								,t13.AnoCorrente								AS AnoCorrente	
								,t0.SkProcesso									AS SkProcesso		
								,t9.NumeroUnico									AS NumeroUnico
								,t9.Protocolo									AS Protocolo
								,t9.Ano											AS Ano
								,t9.IdSistema									AS IdSistema
								,t9.NomeSistema									AS NomeSistema
								,t9.SkTipoTramitacao							AS SkTipoTramitacao
								,t9.EletronicoOuFisico							AS EletronicoOuFisico
								,t9.ValorCausa									AS ValorCausa
								,t9.DataCalculo									AS DataCalculo
								,t9.CabecalhoAtual								AS CabecalhoAtual
								,t9.ExisteParteOptantePorJusticaGratuita		AS ExisteParteOptantePorJusticaGratuita
								,t9.NumeroUnicoFormatado						AS NumeroUnicoFormatado
								,t9.PrioridadePeso								AS PrioridadePeso
								,t9.DataProtocolo								AS DataProtocolo
								,t9.SkEsferaAtual								AS SkEsferaAtual 
								,t10.NomeEsfera									AS NomeEsferaAtual  
								,t0.SkEsfera									AS SkEsfera			
								,t4.NomeEsfera									AS NomeEsfera	
								,t9.SkClasseAtual								AS SkClasseAtual
								,t11.NomeClasse									AS ClasseAtual
								,t0.SkClasse									AS SkClasse				
								,t2.CodigoClasse								AS CodigoClasse		
								,t2.NomeClasse									AS NomeClasse	
								,t9.SkFaseAtual									AS SkFaseAtual
								,t12.DescricaoFase								AS FaseAtual	
								,t0.SkFase										AS SkFase				
								,t5.DescricaoFase								AS DescricaoFase		
								,t5.GrupoFase									AS GrupoFase	
								,t0.SkEstruturaJudiciaria						AS SkEstruturaJudiciaria			
								,t1.NomeEstruturaJudiciaria						AS NomeEstruturaJudiciaria
								,t1.NomeJurisdicaoAbreviado						AS NomeJurisdicao
								,t1.NomeEntranciaAbreviado						AS NomeEntrancia
								,t1.NomeTipoReparticao							AS NomeTipoReparticao
								,t0.SkAssuntoPrincipal							AS SkAssuntoPrincipal					
								,t0.SkTipoEvento								AS SkTipoEvento			
								,t3.NomeTipoEvento								AS NomeTipoEvento		
								,t0.SkComplementoTabelado						AS SkComplementoTabelado		
								,t8.NomeComplementoTabelado						AS NomeComplementoTabelado		
								,t0.SkNivelVisibilidade							AS SkNivelVisibilidade					
								,t7.NivelVisibilidade							AS NivelVisibilidade	
								,t0.IdEvento									AS IdEvento							
								,t0.IdEntidadeNegocio							AS IdEntidadeNegocio					
								,t0.SkOrgaoJulgador								AS SkOrgaoJulgador			
								,t6.NomeAbreviado								AS OrgaoJulgadorNomeAbreviado
								,t0.CnOCrim2									AS CnOCrim2							
								,t0.CnONCrim2									AS CnONCrim2							
								,t0.CnRCrim2									AS CnRCrim2							
								,t0.CnRNCrim2									AS CnRNCrim2							
								,t0.CnCCrim1									AS CnCCrim1							
								,t0.CnCNCrim1									AS CnCNCrim1							
								,t0.CnElet1										AS CnElet1								
								,t0.CnExtFisc1									AS CnExtFisc1							
								,t0.CnExtNFisc1									AS CnExtNFisc1							
								,t0.ExeJudCrimNPL1								AS ExeJudCrimNPL1						
								,t0.ExeJudCrimPL1								AS ExeJudCrimPL1						
								,t0.ExeJudNCrim1								AS ExeJudNCrim1						
								,t0.CnEletTR									AS CnEletTR							
								,t0.CnOCrimTR									AS CnOCrimTR							
								,t0.CnONCrimTR									AS CnONCrimTR							
								,t0.CnElet2										AS CnElet2								
								,t0.CnRCrimTR									AS CnRCrimTR							
								,t0.CnRNCrimTR									AS CnRNCrimTR							
								,t0.CnCCrimJE									AS CnCCrimJE							
								,t0.CnCNCrimJe									AS CnCNCrimJe							
								,t0.CnEletJE									AS CnEletJE							
								,t0.CnExtJE										AS CnExtJE								
								,t0.ExeJudCrimNPLJE								AS ExeJudCrimNPLJE						
								,t0.ExeJudNCrimJE								AS ExeJudNCrimJE						
								,t0.TBaixCrim2									AS TBaixCrim2							
								,t0.TBaixNCrim2									AS TBaixNCrim2							
								,t0.TBaixCCrim1									AS TBaixCCrim1							
								,t0.TBaixCNCrim1								AS TBaixCNCrim1						
								,t0.TBaixExtFisc1								AS TBaixExtFisc1						
								,t0.TBaixExtNFisc1								AS TBaixExtNFisc1						
								,t0.TBaixJudCrimNPL1							AS TBaixJudCrimNPL1					
								,t0.TBaixJudCrimPL1								AS TBaixJudCrimPL1						
								,t0.TBaixJudNCrim1								AS TBaixJudNCrim1						
								,t0.TBaixCrimTR									AS TBaixCrimTR							
								,t0.TBaixNCrimTR								AS TBaixNCrimTR						
								,t0.TBaixCCrimJE								AS TBaixCCrimJE						
								,t0.TBaixCNCrimJE								AS TBaixCNCrimJE						
								,t0.TBaixExtJE									AS TBaixExtJE							
								,t0.TBaixJudCrimNPLJE							AS TBaixJudCrimNPLJE					
								,t0.TBaixJudNCrimJE								AS TBaixJudNCrimJE						
								,t0.DecCrim2									AS DecCrim2							
								,t0.DecH2										AS DecH2								
								,t0.DecNCrim2									AS DecNCrim2							
								,t0.SentCCrim1									AS SentCCrim1							
								,t0.SentCH1										AS SentCH1								
								,t0.SentCNCrim1									AS SentCNCrim1							
								,t0.SentExH1									AS SentExH1							
								,t0.SentExtFisc1								AS SentExtFisc1						
								,t0.SentExtNFisc1								AS SentExtNFisc1						
								,t0.SentJudCrimNPL1								AS SentJudCrimNPL1						
								,t0.SentJudCrimPL1								AS SentJudCrimPL1						
								,t0.SentJudNCrim1								AS SentJudNCrim1						
								,t0.DecCrimTR									AS DecCrimTR							
								,t0.DecHTR										AS DecHTR								
								,t0.DecNCrimTR									AS DecNCrimTR							
								,t0.SentCCrimJE									AS SentCCrimJE							
								,t0.SentCHJE									AS SentCHJE							
								,t0.SentCNCrimJE								AS SentCNCrimJE						
								,t0.SentExHJE									AS SentExHJE							
								,t0.SentExtJE									AS SentExtJE							
								,t0.SentJudCrimNPLJE							AS SentJudCrimNPLJE					
								,t0.SentJudNCrimJE								AS SentJudNCrimJE						
								,t0.IncExJFisc1									AS IncExJFisc1							
								,t0.IncExJNFisc1								AS IncExJNFisc1						
								,t0.IncExJJE									AS IncExJJE							
								,t0.RInt2										AS RInt2								
								,t0.RintJ2										AS RintJ2								
								,t0.RIntC1										AS RIntC1								
								,t0.RIntCJ1										AS RIntCJ1								
								,t0.RintJTR										AS RintJTR								
								,t0.RIntTR										AS RIntTR								
								,t0.RIntCJE										AS RIntCJE								
								,t0.RIntCJJe									AS RIntCJJe							
								,t0.Apublic2									AS Apublic2							
								,t0.RSup2										AS RSup2								
								,t0.DeRExt1										AS DeRExt1								
								,t0.RSup1										AS RSup1								
								,t0.DeImpJE										AS DeImpJE								
								,t0.DeRExtJE									AS DeRExtJE							
								,t0.ISupJE										AS ISupJE								
								,t0.RSupJE										AS RSupJE								
								,t0.ArqNCrim									AS ArqNCrim							
								,t0.ArqNCrimJG									AS ArqNCrimJG							
								,t0.ReatCrim2									AS ReatCrim2							
								,t0.ReatNCrim2									AS ReatNCrim2							
								,t0.ReatCCrim1									AS ReatCCrim1							
								,t0.ReatCNCrim1									AS ReatCNCrim1							
								,t0.ReatExtFisc1								AS ReatExtFisc1						
								,t0.ReatExtNFisc1								AS ReatExtNFisc1						
								,t0.ExeJudRCrimNPL1								AS ExeJudRCrimNPL1						
								,t0.ExeJudRCrimPL1								AS ExeJudRCrimPL1						
								,t0.ExeJudRNcrim1								AS ExeJudRNcrim1						
								,t0.ReatCrimTR									AS ReatCrimTR							
								,t0.ReatNCrimTR									AS ReatNCrimTR							
								,t0.ReatCCrimJE									AS ReatCCrimJE							
								,t0.ReatCNCrimJE								AS ReatCNCrimJE						
								,t0.ReatExtJE									AS ReatExtJE							
								,t0.ExeJudRCrimNPLJE							AS ExeJudRCrimNPLJE					
								,t0.ExeJudRNCrimJE								AS ExeJudRNCrimJE						
								,t0.CartaN2										AS CartaN2								
								,t0.CartaN1										AS CartaN1								
								,t0.CartaNTR									AS CartaNTR							
								,t0.CartaNJE									AS CartaNJE							
								,t0.CartaD2										AS CartaD2								
								,t0.CartaD1										AS CartaD1								
								,t0.CartaDTR									AS CartaDTR							
								,t0.CartaDJE									AS CartaDJE							
								,t0.InqN2										AS InqN2								
								,t0.InqN1										AS InqN1								
								,t0.TeCNJE										AS TeCNJE								
								,t0.InqArq2										AS InqArq2								
								,t0.InqArq1										AS InqArq1								
								,t0.TeCArqJE									AS TeCArqJE							
								,t0.PRedCrim2									AS PRedCrim2							
								,t0.PRedNCrim2									AS PRedNCrim2							
								,t0.PRedCCrim1									AS PRedCCrim1							
								,t0.PRedCNCrim1									AS PRedCNCrim1							
								,t0.PRedExtFisc1								AS PRedExtFisc1						
								,t0.PRedExtNFisc1								AS PRedExtNFisc1						
								,t0.PRedCrimTR									AS PRedCrimTR							
								,t0.PRedNCrimTR									AS PRedNCrimTR							
								,t0.PRedCNCrimJE								AS PRedCNCrimJE						
								,t0.PRedCCrimJE									AS PRedCCrimJE							
								,t0.PRedExJE									AS PRedExJE							
								,t0.SentCCMCrim1								AS SentCCMCrim1						
								,t0.SentCSMCrim1								AS SentCSMCrim1						
								,t0.SentCCMNCrim1								AS SentCCMNCrim1						
								,t0.SentCSMNCrim1								AS SentCSMNCrim1						
								,t0.SentCCMCrimJE								AS SentCCMCrimJE						
								,t0.SentCSMCrimJE								AS SentCSMCrimJE						
								,t0.SentCCMNCrimJE								AS SentCCMNCrimJE						
								,t0.SentCSMNCrimJE								AS SentCSMNCrimJE						
								,t0.QAPR										AS QAPR								
								,t0.QAIR										AS QAIR								
								,t0.QDP											AS QDP									
								,t0.QMP											AS QMP									
								,t0.QJR											AS QJR									
								,t0.CnCVD										AS CnCVD								
								,t0.TbaixCVD									AS TbaixCVD							
								,t0.SentCCMCVD									AS SentCCMCVD							
								,t0.SentCSMCVD									AS SentCSMCVD							
								,t0.ExeJudCrimVD1								AS ExeJudCrimVD1						
								,t0.TbaixJudCrimVD1								AS TbaixJudCrimVD1						
								,t0.SentJudCrimVD1								AS SentJudCrimVD1						
								,t0.InqArqVD1									AS InqArqVD1							
								,t0.InqCPVD1									AS InqCPVD1							
								,t0.InqNVD1										AS InqNVD1								
								,t0.CNCFEM										AS CNCFEM								
								,t0.TbaixCFEM									AS TbaixCFEM							
								,t0.SentCCMCFEM									AS SentCCMCFEM							
								,t0.SentCSMCFEM									AS SentCSMCFEM							
								,t0.ExeJudCrimFEM1								AS ExeJudCrimFEM1						
								,t0.TbaixJudCrimFEM1							AS TbaixJudCrimFEM1					
								,t0.SentJudCrimFEM1								AS SentJudCrimFEM1						
								,t0.InqArqFEM1									AS InqArqFEM1							
								,t0.InqCPFEM1									AS InqCPFEM1							
								,t0.InqNFEM1									AS InqNFEM1							
								,t0.QDIntP										AS QDIntP								
								,t0.PJDistribuido								AS PJDistribuido						
								,t0.PJRedistribuido								AS PJRedistribuido						
								,t0.PJBaixado									AS PJBaixado							
								,t0.PJJulgamento								AS PJJulgamento						
								,t0.Dias										AS Dias								
								,t0.TpTot										AS TpTot								
								,t0.TpDec2										AS TpDec2								
								,t0.TpSentC1									AS TpSentC1							
								,t0.TpSentEx1									AS TpSentEx1							
								,t0.TpDecTR										AS TpDecTR								
								,t0.TpSentCJE									AS TpSentCJE							
								,t0.TpSentExJE									AS TpSentExJE							
								,t0.TpBaixCrim2									AS TpBaixCrim2							
								,t0.TpBaixNCrim2								AS TpBaixNCrim2						
								,t0.TpBaixCCrim1								AS TpBaixCCrim1						
								,t0.TpBaixCNCrim1								AS TpBaixCNCrim1						
								,t0.TpBaixExtFisc1								AS TpBaixExtFisc1						
								,t0.TpBaixExtNFisc1								AS TpBaixExtNFisc1						
								,t0.TpBaixJudCrimPL1							AS TpBaixJudCrimPL1					
								,t0.TpBaixJudCrimNPL1							AS TpBaixJudCrimNPL1					
								,t0.TpBaixJudNCrim1								AS TpBaixJudNCrim1						
								,t0.TpBaixCrimTR								AS TpBaixCrimTR						
								,t0.TpBaixNCrimTR								AS TpBaixNCrimTR						
								,t0.TpBaixCCrimJE								AS TpBaixCCrimJE						
								,t0.TpBaixCNCrimJE								AS TpBaixCNCrimJE						
								,t0.TpBaixExtJE									AS TpBaixExtJE							
								,t0.TpBaixJudCrimNPlJE							AS TpBaixJudCrimNPlJE					
								,t0.TpBaixJudNCrimJE							AS TpBaixJudNCrimJE					
								,t0.AudConc2									AS AudConc2							
								,t0.AudNConc2									AS AudNConc2							
								,t0.DecDC2										AS DecDC2								
								,t0.DecHDC2										AS DecHDC2								
								,t0.DecInt2										AS DecInt2								
								,t0.PRedRCrim2									AS PRedRCrim2							
								,t0.PRedRNCrim2									AS PRedRNCrim2							
								,t0.ProcInvArq2									AS ProcInvArq2							
								,t0.ProcInvN2									AS ProcInvN2							
								,t0.VotoRCrim2									AS VotoRCrim2							
								,t0.VotoRNCrim2									AS VotoRNCrim2							
								,t0.VPfGCrim2									AS VPfGCrim2							
								,t0.VPfGNCrim2									AS VPfGNCrim2							
								,t0.VPnGCrim2									AS VPnGCrim2							
								,t0.VPnGNCrim2									AS VPnGNCrim2							
								,t0.AudConcTR									AS AudConcTR							
								,t0.AudNConcTR									AS AudNConcTR							
								,t0.DecDCTR										AS DecDCTR								
								,t0.DecHDCTR									AS DecHDCTR							
								,t0.DecIntTR									AS DecIntTR							
								,t0.PRedRCrimTR									AS PRedRCrimTR							
								,t0.PRedRNCrimTR								AS PRedRNCrimTR						
								,t0.VotoRCrimTR									AS VotoRCrimTR							
								,t0.VotoRNCrimTR								AS VotoRNCrimTR						
								,t0.VPfGCrimTR									AS VPfGCrimTR							
								,t0.VPfGNCrimTR									AS VPfGNCrimTR							
								,t0.VPnGCrimTR									AS VPnGCrimTR							
								,t0.VPnGNCrimTR									AS VPnGNCrimTR							
								,t0.AudConc1									AS AudConc1							
								,t0.AudNConc1									AS AudNConc1							
								,t0.DecInt1										AS DecInt1								
								,t0.DecJudCrim1									AS DecJudCrim1							
								,t0.PRedRCCrim1									AS PRedRCCrim1							
								,t0.PRedRCNCrim1								AS PRedRCNCrim1						
								,t0.PRedRExtFisc1								AS PRedRExtFisc1						
								,t0.PRedRExtNFisc1								AS PRedRExtNFisc1						
								,t0.ProcInvArq1									AS ProcInvArq1							
								,t0.ProcInvN1									AS ProcInvN1							
								,t0.SentDC1										AS SentDC1								
								,t0.SentHDC1									AS SentHDC1							
								,t0.AudConcJE									AS AudConcJE							
								,t0.AudNConcJE									AS AudNConcJE							
								,t0.DecIntJE									AS DecIntJE							
								,t0.DecJudCrimJE								AS DecJudCrimJE						
								,t0.PRedCRecNCrimJE								AS PRedCRecNCrimJE						
								,t0.PRedRCCrimJE								AS PRedRCCrimJE						
								,t0.PRedRExJE									AS PRedRExJE							
								,t0.ProcInvArqJE								AS ProcInvArqJE						
								,t0.ProcInvNJE									AS ProcInvNJE							
								,t0.SentDCJE									AS SentDCJE							
								,t0.SentHDCJE									AS SentHDCJE							
								,t0.Despacho									AS Despacho							
								,t0.ImpactoNaRes76								AS ImpactoNaRes76						
								,t0.IdEntidadeNegocioGeradora					AS IdEntidadeNegocioGeradora			
								,t0.PRedRCNCrimJE								AS PRedRCNCrimJE						
								,t0.SkTipoReparticao							AS SkTipoReparticao					
								,t0.SkGabinete									AS SkGabinete							
								,t0.CnOCrim2_cejusc								AS CnOCrim2_cejusc						
								,t0.CnONCrim2_cejusc							AS CnONCrim2_cejusc					
								,t0.CnRCrim2_cejusc								AS CnRCrim2_cejusc						
								,t0.CnRNCrim2_cejusc							AS CnRNCrim2_cejusc					
								,t0.CnCCrim1_cejusc								AS CnCCrim1_cejusc						
								,t0.CnCNCrim1_cejusc							AS CnCNCrim1_cejusc					
								,t0.CnOCrimTR_cejusc							AS CnOCrimTR_cejusc					
								,t0.CnONCrimTR_cejusc							AS CnONCrimTR_cejusc					
								,t0.CnRCrimTR_cejusc							AS CnRCrimTR_cejusc					
								,t0.CnRNCrimTR_cejusc							AS CnRNCrimTR_cejusc					
								,t0.CnCCrimJE_cejusc							AS CnCCrimJE_cejusc					
								,t0.CnCNCrimJE_cejusc							AS CnCNCrimJE_cejusc					
								,t0.CnRPP_cejusc								AS CnRPP_cejusc						
								,t0.TBaixOCrim2_cejusc							AS TBaixOCrim2_cejusc					
								,t0.TBaixONCrim2_cejusc							AS TBaixONCrim2_cejusc					
								,t0.TBaixRCrim2_cejusc							AS TBaixRCrim2_cejusc					
								,t0.TBaixRNCrim2_cejusc							AS TBaixRNCrim2_cejusc					
								,t0.TBaixCCrim1_cejusc							AS TBaixCCrim1_cejusc					
								,t0.TBaixCNCrim1_cejusc							AS TBaixCNCrim1_cejusc					
								,t0.TBaixOCrimTR_cejusc							AS TBaixOCrimTR_cejusc					
								,t0.TBaixONCrimTR_cejusc						AS TBaixONCrimTR_cejusc				
								,t0.TBaixRCrimTR_cejusc							AS TBaixRCrimTR_cejusc					
								,t0.TBaixRNCrimTR_cejusc						AS TBaixRNCrimTR_cejusc				
								,t0.TBaixCCrimJE_cejusc							AS TBaixCCrimJE_cejusc					
								,t0.TBaixCNCrimJE_cejusc						AS TBaixCNCrimJE_cejusc				
								,t0.TBaixRPP_cejusc								AS TBaixRPP_cejusc						
								,t0.AudConcRealOCrim2_cejusc					AS AudConcRealOCrim2_cejusc			
								,t0.AudMedRealOCrim2_cejusc						AS AudMedRealOCrim2_cejusc				
								,t0.AudConcRealONCrim2_cejusc					AS AudConcRealONCrim2_cejusc			
								,t0.AudMedRealONCrim2_cejusc					AS AudMedRealONCrim2_cejusc			
								,t0.AudArt334RealONCrim2_cejusc					AS AudArt334RealONCrim2_cejusc			
								,t0.AudConcRealRCrim2_cejusc					AS AudConcRealRCrim2_cejusc			
								,t0.AudMedRealRCrim2_cejusc						AS AudMedRealRCrim2_cejusc				
								,t0.AudConcRealRNCrim2_cejusc					AS AudConcRealRNCrim2_cejusc			
								,t0.AudMedRealRNCrim2_cejusc					AS AudMedRealRNCrim2_cejusc			
								,t0.AudConcRealCCrim1_cejusc					AS AudConcRealCCrim1_cejusc			
								,t0.AudMedRealCCrim1_cejusc						AS AudMedRealCCrim1_cejusc				
								,t0.AudConcRealCNCrim1_cejusc					AS AudConcRealCNCrim1_cejusc			
								,t0.AudMedRealCNCrim1_cejusc					AS AudMedRealCNCrim1_cejusc			
								,t0.AudArt334RealCNCrim1_cejusc					AS AudArt334RealCNCrim1_cejusc			
								,t0.AudConcRealOCrimTR_cejusc					AS AudConcRealOCrimTR_cejusc			
								,t0.AudMedRealOCrimTR_cejusc					AS AudMedRealOCrimTR_cejusc			
								,t0.AudConcRealONCrimTR_cejusc					AS AudConcRealONCrimTR_cejusc			
								,t0.AudMedRealONCrimTR_cejusc					AS AudMedRealONCrimTR_cejusc			
								,t0.AudArt334RealONCrimTR_cejusc				AS AudArt334RealONCrimTR_cejusc		
								,t0.AudConcRealCCrimJE_cejusc					AS AudConcRealCCrimJE_cejusc			
								,t0.AudMedRealCCrimJE_cejusc					AS AudMedRealCCrimJE_cejusc			
								,t0.AudConcRealCNCrimJE_cejusc					AS AudConcRealCNCrimJE_cejusc			
								,t0.AudMedRealCNCrimJE_cejusc					AS AudMedRealCNCrimJE_cejusc			
								,t0.AudConcRealRPP_cejusc						AS AudConcRealRPP_cejusc				
								,t0.AudMedRealRPP_cejusc						AS AudMedRealRPP_cejusc				
								,t0.AcordosRPP_cejusc							AS AcordosRPP_cejusc					
								,t0.ImpactoNaCejusc								AS ImpactoNaCejusc						
								,t0.SentCH1_cejusc								AS SentCH1_cejusc						
								,t0.SentCHJE_cejusc								AS SentCHJE_cejusc						
								,t0.DecH2_cejusc								AS DecH2_cejusc						
								,t0.DecHTR_cejusc								AS DecHTR_cejusc						
								,t0.SkTipoEventoProprio							AS SkTipoEventoProprio					
								,t0.DataHora									AS DataHora							
								,t0.AudConcPRE_Nupemec							AS AudConcPRE_Nupemec					
								,t0.SentPre_Nupemec								AS SentPre_Nupemec						
								,t0.SentCHNcrim1_Nupemec						AS SentCHNcrim1_Nupemec				
								,t0.SentCHNcrimJE_Nupemec						AS SentCHNcrimJE_Nupemec				
								,t0.DecHNcrim2_Nupemec							AS DecHNcrim2_Nupemec					
								,t0.DecHNcrimTR_Nupemec							AS DecHNcrimTR_Nupemec					
								,t0.AudConc1_Nupemec							AS AudConc1_Nupemec					
								,t0.AudConcJE_Nupemec							AS AudConcJE_Nupemec					
								,t0.AudConcTR_Nupemec							AS AudConcTR_Nupemec					
								,t0.AudConc2_Nupemec							AS AudConc2_Nupemec					
								,t0.CnPre_Nupemec								AS CnPre_Nupemec						
								,t0.SentHDCJE_Nupemec							AS SentHDCJE_Nupemec					
								,t0.SentHDC1_Nupemec							AS SentHDC1_Nupemec		

							INTO #FatoProcessoEvento
							FROM OMNI_DW.Juridico.FatoProcessoEvento			t0
							LEFT JOIN pj.DimEstruturaJudiciaria					t1  on t1.SkEstruturaJudiciaria	= t0.SkEstruturaJudiciaria
							LEFT JOIN cnj.DimClasse								t2  on t2.SkClasse				= t0.SkClasse
							LEFT JOIN cnj.DimTipoEvento							t3  on t3.SkTipoEvento			= t0.SkTipoEvento
							LEFT JOIN Juridico.DimEsfera						t4  on t4.SkEsfera				= t0.SkEsfera
							LEFT JOIN Juridico.DimFase							t5  on t5.SkFase				= t0.SkFase
							LEFT JOIN pj.DimOrgaoJulgador						t6  on t6.SkOrgaoJulgador		= t0.SkOrgaoJulgador
							LEFT JOIN Juridico.DimNivelVisibilidade				t7  on t7.SkNivelVisibilidade	= t0.SkNivelVisibilidade
							LEFT JOIN CNJ.DimComplementoTabelado				t8  on t8.SkComplementoTabelado	= t0.SkComplementoTabelado
							LEFT JOIN Juridico.DimProcesso						t9  on t9.SkProcesso			= t0.SkProcesso
							LEFT JOIN Juridico.DimEsfera						t10 on t10.SkEsfera				= t9.SkEsferaAtual
							LEFT JOIN cnj.DimClasse								t11 on t11.SkClasse				= t9.SkClasseAtual
							LEFT JOIN Juridico.DimFase							t12 on t12.SkFase				= t9.SkFaseAtual
							LEFT JOIN Base.DimTempo								t13 on t13.SkTempo				= t0.SkTempo
							WHERE 1=1
			

                ";

		return query;
    }
}