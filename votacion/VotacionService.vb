Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports SistemaDeVotacionOnlineConRegistrosEnBlockchain.Contracts.votacion.ContractDefinition
Namespace SistemaDeVotacionOnlineConRegistrosEnBlockchain.Contracts.votacion


    Public Partial Class VotacionService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal votacionDeployment As VotacionDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of VotacionDeployment)().SendRequestAndWaitForReceiptAsync(votacionDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal votacionDeployment As VotacionDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of VotacionDeployment)().SendRequestAsync(votacionDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal votacionDeployment As VotacionDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of VotacionService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, votacionDeployment, cancellationTokenSource)
            Return New VotacionService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function RepresentarRequestAsync(ByVal representarFunction As RepresentarFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of RepresentarFunction)(representarFunction)
        
        End Function

        Public Function RepresentarRequestAndWaitForReceiptAsync(ByVal representarFunction As RepresentarFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of RepresentarFunction)(representarFunction, cancellationToken)
        
        End Function

        
        Public Function RepresentarRequestAsync(ByVal [nombrePersona] As String, ByVal [edadPersona] As BigInteger, ByVal [idPersona] As String) As Task(Of String)
        
            Dim representarFunction = New RepresentarFunction()
                representarFunction.NombrePersona = [nombrePersona]
                representarFunction.EdadPersona = [edadPersona]
                representarFunction.IdPersona = [idPersona]
            
            Return ContractHandler.SendRequestAsync(Of RepresentarFunction)(representarFunction)
        
        End Function

        
        Public Function RepresentarRequestAndWaitForReceiptAsync(ByVal [nombrePersona] As String, ByVal [edadPersona] As BigInteger, ByVal [idPersona] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim representarFunction = New RepresentarFunction()
                representarFunction.NombrePersona = [nombrePersona]
                representarFunction.EdadPersona = [edadPersona]
                representarFunction.IdPersona = [idPersona]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of RepresentarFunction)(representarFunction, cancellationToken)
        
        End Function
        Public Function OwnerQueryAsync(ByVal ownerFunction As OwnerFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            Return ContractHandler.QueryAsync(Of OwnerFunction, String)(ownerFunction, blockParameter)
        
        End Function

        
        Public Function OwnerQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of String)
        
            return ContractHandler.QueryAsync(Of OwnerFunction, String)(Nothing, blockParameter)
        
        End Function



        Public Function VerCandidatosQueryAsync(ByVal verCandidatosFunction As VerCandidatosFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of List(Of String))
        
            Return ContractHandler.QueryAsync(Of VerCandidatosFunction, List(Of String))(verCandidatosFunction, blockParameter)
        
        End Function

        
        Public Function VerCandidatosQueryAsync(ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of List(Of String))
        
            return ContractHandler.QueryAsync(Of VerCandidatosFunction, List(Of String))(Nothing, blockParameter)
        
        End Function



        Public Function VotarRequestAsync(ByVal votarFunction As VotarFunction) As Task(Of String)
                    
            Return ContractHandler.SendRequestAsync(Of VotarFunction)(votarFunction)
        
        End Function

        Public Function VotarRequestAndWaitForReceiptAsync(ByVal votarFunction As VotarFunction, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of VotarFunction)(votarFunction, cancellationToken)
        
        End Function

        
        Public Function VotarRequestAsync(ByVal [candidato] As String) As Task(Of String)
        
            Dim votarFunction = New VotarFunction()
                votarFunction.Candidato = [candidato]
            
            Return ContractHandler.SendRequestAsync(Of VotarFunction)(votarFunction)
        
        End Function

        
        Public Function VotarRequestAndWaitForReceiptAsync(ByVal [candidato] As String, ByVal Optional cancellationToken As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Dim votarFunction = New VotarFunction()
                votarFunction.Candidato = [candidato]
            
            Return ContractHandler.SendRequestAndWaitForReceiptAsync(Of VotarFunction)(votarFunction, cancellationToken)
        
        End Function
    
    End Class

End Namespace
