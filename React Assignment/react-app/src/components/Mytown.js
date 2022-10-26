import React, { Component } from "react"
import image from './halifax.jpg'

class Mytown extends Component {
    // constructor(props)
    // {
    //     super(props)
    //     this.state={
    //         weatherData : 
    //     }
    // }
    componentDidMount()
    {
        this.getweatherData();
    }
    getweatherData()
    {
        fetch("https://api.openweathermap.org/data/2.5/weather?lat=44.651070&lon=-63.582687&appid=d70de8ba96b2f5e4b69f5c8cefeb95bd").then(res => res.json()).then(data => console.log(data));
    }

    render() {
        return (
            <div>
            <img src={image} width={325} alt = "My pic"/>
          <h1>I live in Halifax, Nova Scotia</h1>
           <p>Halifax is the capital and largest municipality of the Canadian province of Nova Scotia, and the largest municipality in Atlantic Canada. 
           Halifax is a major economic centre in Atlantic Canada, with a large concentration of government services and private sector companies.</p>
          </div>
        //   <script src='https://www.weatherapi.com/weather/widget.ashx?loc=314643&wid=1&tu=2&div=weatherapi-weather-widget-1' async></script><noscript>
        
        )
    }
}

export default Mytown;