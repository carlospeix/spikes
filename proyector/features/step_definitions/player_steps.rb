require File.join(File.dirname(__FILE__),'../../lib/proyector')
require File.join(File.dirname(__FILE__),'../../lib/timer_test')

Given(/^El proyector esta encendido$/) do
	@@timer = TimerTest.new
	@@proyector = Proyector.new(@@timer)
	@@proyector.encender
end

When(/^Apago el proyector$/) do
	@@proyector.apagar
end

Then(/^el ventilador esta encendido$/) do
	@@proyector.ventilador_encendido.should be true
end

When(/^pasan (\d+) segundos$/) do |segundos|
	@@timer.avanzar_segundos(segundos.to_i)
end

Then(/^el ventilador esta apagado$/) do
	@@proyector.ventilador_encendido.should be false
end
