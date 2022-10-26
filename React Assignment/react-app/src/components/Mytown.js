import React, { Component } from "react"
import image from './halifax.jpg'
import imagesource from './mild.png'
import imagesource1 from './cold.png'
import imagesource2 from './sunny.png'


class Mytown extends Component {
    constructor(props)
    {
        super(props)
        this.state={
            weatherData : 0,
            isshowCel:true,
            // temp:12,
            random:0,
            imagename:"",
            tempunit:'C'
            

            // imagesource : './mild.png'
        }
    }
    handleClick() {
        const min = 1;
        const max =30;
        const rand = Math.round(min + Math.random() * (max - min));
        this.setState({ random: this.state.random + rand });
      }
    componentDidMount()
    {
        this.getweatherData();
        this.handleClick();
    }
    getweatherData()
    {
        fetch("https://api.openweathermap.org/data/2.5/weather?lat=44.651070&lon=-63.582687&appid=047a4bc27a0c9acf3eb9c1d8844f6c26")
        .then(res => res.json())
        .then(data => this.setState({temp: ((data.main.temp))
        }));
    }

    render() {
        return (
            <div>
            <img src={image} width={325} alt = "My pic"/>
          <h1>I live in Halifax, Nova Scotia</h1>
           <p>Halifax is the capital and largest municipality of the Canadian province of Nova Scotia, and the largest municipality in Atlantic Canada. 
           Halifax is a major economic centre in Atlantic Canada, with a large concentration of government services and private sector companies.</p>
           <img src={this.state.random<10? imagesource1:(this.state.random<20?imagesource:imagesource2)} width={125} alt = {"weather"}/>
           <p>{this.state.isshowCel === true? this.state.random:((this.state.random*1.8)+32)}°{this.state.isshowCel === true?this.state.tempunit:'F'}</p>
           
           <button
                    onClick={() => this.setState({ isshowCel: !this.state.isshowCel })}
                    className="btn-capital-show"                >
                    {this.state.isshowCel ? "Change to Fahrenheit" : "Change to Celsius"}
                </button>
          </div>
        
        )
    }
}

export default Mytown;