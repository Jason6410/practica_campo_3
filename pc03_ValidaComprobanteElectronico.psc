Algoritmo pc03_ValidaComprobanteElectronico
	comprobante <- "F001-00001234"
	esCorrecto <- ValidarComprobanteElectronico(comprobante)
	Escribir "El comprobante ", comprobante, " es: ", esCorrecto
FinAlgoritmo

Funcion esValido <- ValidarComprobanteElectronico(numero)
	esValido <- Verdadero;
	contadorGuiones <- 0;
	posicionGuion <- 0;
	
	// Caso invalido por cadena vacia
	Si Longitud(numero) = 0 Entonces
		esValido <- Falso;
	FinSi
	
	// Buscar el guion recorriendo la cadena caracter por caracter
	Si esValido Entonces
		Para i <- 1 Hasta Longitud(numero) Con Paso 1
			Si SubCadena(numero,i,i) = "-" Entonces
				contadorGuiones <- contadorGuiones + 1;
				Si posicionGuion = 0 Entonces
					posicionGuion <- i;
				FinSi
			FinSi
		FinPara
		
		// Debe existir exactamente un guion (equivale a partes.Length = 2)
		Si contadorGuiones <> 1 Entonces
			esValido <- Falso;
		FinSi
	FinSi
	
	Si esValido Entonces
		serie <- SubCadena(numero,1,posicionGuion-1);
		correlativo <- SubCadena(numero,posicionGuion+1,Longitud(numero));
		
		// Validar longitud de la serie (debe ser 4: letra + 3 digitos)
		Si Longitud(serie) <> 4 Entonces
			esValido <- Falso;
		FinSi
		
		// Validar primer caracter de la serie (debe ser B o F)
		Si esValido Y SubCadena(serie,1,1) <> "B" Y SubCadena(serie,1,1) <> "F" Entonces
			esValido <- Falso;
		FinSi
		
		// Validar que los siguientes 3 caracteres de la serie sean digitos
		Si esValido Entonces
			Para i <- 2 Hasta 4 Con Paso 1
				Si NO EsDigito(SubCadena(serie,i,i)) Entonces
					esValido <- Falso;
				FinSi
			FinPara
		FinSi
		
		// Validar longitud del correlativo (debe ser 8 digitos)
		Si esValido Y Longitud(correlativo) <> 8 Entonces
			esValido <- Falso;
		FinSi
		
		// Validar que todo el correlativo sean digitos
		Si esValido Entonces
			Para i <- 1 Hasta Longitud(correlativo) Con Paso 1
				Si NO EsDigito(SubCadena(correlativo,i,i)) Entonces
					esValido <- Falso;
				FinSi
			FinPara
		FinSi
	FinSi
FinFuncion

Funcion resultado <- EsDigito(caracter)
	resultado <- (caracter >= "0" Y caracter <= "9");
FinFuncion