class TimerTest
	def iniciar(tiempo_en_segundos, when_elapsed)
		@tiempo_en_segundos = tiempo_en_segundos
		@when_elapsed = when_elapsed
	end

	def avanzar_segundos(segundos)
		if segundos >= @tiempo_en_segundos
			@when_elapsed.call
		end
	end
end