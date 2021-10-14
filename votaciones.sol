//SPDX-License-Identifier: MIT
pragma solidity >=0.4.0  < 0.9.0;
pragma experimental ABIEncoderV2; //Abiencoder es para calcular hashes

//Candidato // EDAD // ID
// TONI     // 20   // 201
// Alberto  // 35   // 203
// Mirta    // 21   // 201
// Pato     // 26   // 001

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
    bytes32[] votantes;
 
    //Constructor
    constructor () public {
        owner = msg.sender;
    }

    //Funcion que te permite presentarte como candidato.
    //Memory, fuerza a que la variable se elimine una ves la funcion finalice.
    function Representar(string memory _nombrePersona,uint _edadPersona, string memory _idPersona) public {
        //hash de los datos del candidato.
        bytes32 hash_Candidato = keccak256(abi.encodePacked(_nombrePersona, _edadPersona, _idPersona));
        //almacenar el hash de los datos del candidato que estan ligados a su nombre
        ID_Candidato[_nombrePersona] = hash_Candidato;
        
        //Actualizamos la lista de los candidatos.
        candidatos.push(_nombrePersona);
    }

    //Esta funcion nos permite ver el vector de candidatos. String es un vector de nombres.
    function verCandidatos() public view returns(string[] memory){
        //Devuelve la lista de los candidatos presentados
        return candidatos;
    }

    //Los votatantes usaran esta funcion para elegir a su candidato y votarlo
    function votar(string memory _candidato) public {
        //hash de la direccion de la persona que ejecuta esta funcion
        bytes32 hash_Votante = keccak256(abi.encodePacked(msg.sender));
        //verificamos si el votante ya a votado.
        for(uint i= 0; i < votantes.length; i++){
            require(votantes[i] != hash_Votante, "Ya votaste" );
        }
        //Almacenamos el hash del votante deltro del array de votantes
        votantes.push(hash_Votante);
        //Añadimos un voto al candidato seleccinado
        votos_Candidato[_candidato]++;
    }


    //La cantidad de votos que tiene uun candidato.
    function verVotos(string memory _nombreCandidato) public view returns(uint){
        return votos_Candidato[_nombreCandidato];
    }

    //Funcion auxiliar que transforma un uint a un string

    function uint2str(uint _i) internal pure returns (string memory _uintAsString) {
        if (_i == 0) {
            return "0";
        }
        uint j = _i;
        uint len;
        while (j != 0) {
            len++;
            j /= 10;
        }
        bytes memory bstr = new bytes(len);
        uint k = len - 1;
        while (_i != 0) {
            bstr[k--] = byte(uint8(48 + _i % 10));
            _i /= 10;
        }
        return string(bstr);
    }

    //Ver los votos de cada uno de los candidatos.
    function VerResultados() public view returns(string[] memory){
        //guardamos en una variable los string los candidatos con sus respectivos votos
        string memory resultados;

        //Recorremos el array de candidatos para actualizar el string resultados
        for(uint i=0; i < candidatos.length; i++ ){
            //transformacion de bytes a string.
            //Actualizamos el string resultados, y añadimos el candidato que ocupa la posicion "i" del array candidatos
            // y su numero de votoss
            resultados = string(abi.encodePacked(resultados,"C", candidatos[i], " ,", uint2str(verVotos(candidatos[i])), ")" ));
        }
        //devolvemos los resultados.
        return resultados;
    }

    //Proporcionar el nombre del candidato ganador
    function Ganador() public view returns(string memory){
        //la variable ganador va a contener el nombre del candidato ganador.
        string memory ganador = candidatos[0];
        //variable flag para empate
        bool flag;

        //recorremos el array de candidatos para determinar el candidato con un numero mayor de votos
        for(uint i=1; i < candidatos.length; i++ ){
            
            //comparamos si nuestro ganador ha sido superado por otro candidato.
           if( votos_Candidato[candidatos[i]] > votos_candidato[ganador]){
               ganador= candidatos[i];
               flag=false;
           }else {
               //miramos si hay empate entre los candidatos
               if(votos_Candidato[candidatos[i]] == votos_candidato[ganador]){
                   flag=true;            
               }
           }
        }
        //comprobamos si ha habido un empate entre los candidatos
        if (flag==true){
            ganador = "hay un empate entre los candiadatos";
        } 
        //devolvemos el ganador
        return ganador;
    }
}