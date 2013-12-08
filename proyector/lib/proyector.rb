class Proyector
	def initialize(timer)
		@timer = timer
		@ventilador_encendido = false
	end

	def encender
		@ventilador_encendido = true
	end

	def apagar
		@timer.iniciar 20, lambda { @ventilador_encendido = false }
	end

	def ventilador_encendido
		return @ventilador_encendido
	end
end