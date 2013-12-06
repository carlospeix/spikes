class Proyector
	def initialize(timer)
		@timer = timer
	end

	def encender
	end

	def apagar
		@timer.iniciar(20)
	end

	def ventilador_encendido
		if @timer.elapsed
			false
		else
			true
		end
	end
end