Feature: Sistema termico

	Como proyector
	Deseo que mi temperatura interna este regulada
	Para evitar que se dañe la lampara o componententes internos

	Scenario: Apago el proyector, ventilador sigue encendido
	Given El proyector esta encendido
	When Apago el proyector
	Then el ventilador esta encendido

	Scenario: Apagado, apaga a los 20 segundos (1)
	Given El proyector esta encendido
	When Apago el proyector
	And pasan 19 segundos
	Then el ventilador esta encendido

	Scenario: Apagado, apaga a los 20 segundos (2)
	Given El proyector esta encendido
	When Apago el proyector
	And pasan 21 segundos
	Then el ventilador esta apagado
