require 'open-uri'
require 'nokogiri'

describe "crawler" do
  it "should detect website available with 'http://es.wisuki.com/tide/4059/quilmes'" do
    response = navigate_site("http://es.wisuki.com/tide/4059/quilmes")
    response.should == true
  end
  it "should detect website not available with 'http://es.wisuki.nonexistent/tide/4059/quilmes/'"
end

def navigate_site(site)
  
  doc = Nokogiri::HTML(open(site))
  doc.xpath("//*[@id='content']/table[1]/thead").each do |line|
    line
  end

end