class TimerTest
	def iniciar(tiempo_en_segundos)
		@elapsed = false
		@tiempo_en_segundos = tiempo_en_segundos
	end
	def elapsed
		@elapsed
	end

	def avanzar_segundos(segundos)
		@elapsed = segundos >= @tiempo_en_segundos
	end
end