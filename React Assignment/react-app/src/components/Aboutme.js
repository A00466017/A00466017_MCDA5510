import React, { Component } from "react"
import image from './My pic.jpeg'
class Aboutme extends Component {


    render() {
        return (
            <div>
             <img src={image} width={325} alt = "My pic"/>
           <h1>Hi, I am Abhishek</h1>
           <p>I am a Data Analyst by profession. I graduated in 2015 with Bachelors of Technology in Computer Science and Engineering.
            My primary industry experience has been in retail and automobiles. 
            I have been working on Data Analysis, Business Intelligence, and Data Science for around 7 years. 
            The goal of my career is to become an expert in the field of Machine Learning and Artificial Intelligence.
            I have previously worked with Nissan Motor Corporation and Mu Sigma Business solutions. I love playing football and exploring new places</p>
            <p>I have joined MCDA to improve my data science skills and strengthen my knowledge in statistics. I would also like to get more exposure in the International market</p>
           </div>
        )
    }
}

export default Aboutme;