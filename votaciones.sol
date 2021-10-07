//SPDX-License-Identifier: MIT
pragma solidity >=0.4.0  < 0.9.0;
pragma experimental ABIEncoderV2; //Abiencoder es para calcular hashes

//Candidato // EDAD // ID
// TONI     // 20   // 201
// Alberto // 35   // 203
// Mirta   // 21   // 201
//Pato     // 26   // 001

contract votacion {

    //Direccion del propietario del contrato.
    address public owner;

    //Relacion entre el nombre y el hash de sus datos personales. 
    mapping(string => bytes32) ID_Candidato;
    
    //Relacion entre el nombre del candidato y el numero de votos. 
    mapping(string => uint) votos_Candidato;

    //Lista para almacenar los nombres de los candidatos.
    string[] candidatos;

    //Lista de los hashes de la identidad de los votantes. Con validacion, usamos bytes32 para mantener el anonimato.
    bytes32[] votatantes;
 
    //Constructor
    constructor () public {
        owner = msg.sender;
    }

    


}