Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts
Imports System.Threading
Namespace SistemaDeVotacionOnlineConRegistrosEnBlockchain.Contracts.votacion.ContractDefinition

    
    
    Public Partial Class VotacionDeployment
     Inherits VotacionDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class VotacionDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "608060405234801561001057600080fd5b50600080546001600160a01b03191633179055610587806100326000396000f3fe608060405234801561001057600080fd5b506004361061004c5760003560e01c80638da5cb5b14610051578063caaa49a614610081578063ce3fe64114610096578063f01ca6b7146100a9575b600080fd5b600054610064906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b6100896100bc565b60405161007891906102fc565b6100a76100a4366004610419565b50565b005b6100a76100b7366004610456565b610195565b60606003805480602002602001604051908101604052809291908181526020016000905b8282101561018c5783829060005260206000200180546100ff906104c3565b80601f016020809104026020016040519081016040528092919081815260200182805461012b906104c3565b80156101785780601f1061014d57610100808354040283529160200191610178565b820191906000526020600020905b81548152906001019060200180831161015b57829003601f168201915b5050505050815260200190600101906100e0565b50505050905090565b60008383836040516020016101ac939291906104fe565b604051602081830303815290604052805190602001209050806001856040516101d59190610535565b908152604051602091819003820190209190915560038054600181018255600091909152855161022c927fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b90920191870190610233565b5050505050565b82805461023f906104c3565b90600052602060002090601f01602090048101928261026157600085556102a7565b82601f1061027a57805160ff19168380011785556102a7565b828001600101855582156102a7579182015b828111156102a757825182559160200191906001019061028c565b506102b39291506102b7565b5090565b5b808211156102b357600081556001016102b8565b60005b838110156102e75781810151838201526020016102cf565b838111156102f6576000848401525b50505050565b6000602080830181845280855180835260408601915060408160051b870101925083870160005b8281101561036957878503603f190184528151805180875261034a818989018a85016102cc565b601f01601f191695909501860194509285019290850190600101610323565b5092979650505050505050565b634e487b7160e01b600052604160045260246000fd5b600082601f83011261039d57600080fd5b813567ffffffffffffffff808211156103b8576103b8610376565b604051601f8301601f19908116603f011681019082821181831017156103e0576103e0610376565b816040528381528660208588010111156103f957600080fd5b836020870160208301376000602085830101528094505050505092915050565b60006020828403121561042b57600080fd5b813567ffffffffffffffff81111561044257600080fd5b61044e8482850161038c565b949350505050565b60008060006060848603121561046b57600080fd5b833567ffffffffffffffff8082111561048357600080fd5b61048f8783880161038c565b94506020860135935060408601359150808211156104ac57600080fd5b506104b98682870161038c565b9150509250925092565b600181811c908216806104d757607f821691505b602082108114156104f857634e487b7160e01b600052602260045260246000fd5b50919050565b600084516105108184602089016102cc565b820184815283516105288160208085019088016102cc565b0160200195945050505050565b600082516105478184602087016102cc565b919091019291505056fea26469706673582212207b0c86ee699fe7a72b7259c21b63831df2f1d3ac49e56e190d21d968cb21338364736f6c63430008090033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class RepresentarFunction
        Inherits RepresentarFunctionBase
    End Class

        <[Function]("Representar")>
    Public Class RepresentarFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("string", "_nombrePersona", 1)>
        Public Overridable Property [NombrePersona] As String
        <[Parameter]("uint256", "_edadPersona", 2)>
        Public Overridable Property [EdadPersona] As BigInteger
        <[Parameter]("string", "_idPersona", 3)>
        Public Overridable Property [IdPersona] As String
    
    End Class
    
    
    Public Partial Class OwnerFunction
        Inherits OwnerFunctionBase
    End Class

        <[Function]("owner", "address")>
    Public Class OwnerFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class VerCandidatosFunction
        Inherits VerCandidatosFunctionBase
    End Class

        <[Function]("verCandidatos", "string[]")>
    Public Class VerCandidatosFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class VotarFunction
        Inherits VotarFunctionBase
    End Class

        <[Function]("votar")>
    Public Class VotarFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("string", "_candidato", 1)>
        Public Overridable Property [Candidato] As String
    
    End Class
    
    
    
    
    Public Partial Class OwnerOutputDTO
        Inherits OwnerOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class OwnerOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("address", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class VerCandidatosOutputDTO
        Inherits VerCandidatosOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class VerCandidatosOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string[]", "", 1)>
        Public Overridable Property [ReturnValue1] As List(Of String)
    
    End Class    
    

End Namespace
