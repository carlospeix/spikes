class Proyector
	def initialize(timer)
		@timer = timer
		@ventilador_encendido = false
	end

	def encender
		@ventilador_encendido = true
	end

	def apagar
		@timer.iniciar 20, method(:apagar_ventilador)
	end

	def ventilador_encendido
		return @ventilador_encendido
	end

	private

	def apagar_ventilador
		@ventilador_encendido = false
	end
end