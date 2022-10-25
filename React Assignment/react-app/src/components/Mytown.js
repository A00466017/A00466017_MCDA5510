import React, { Component } from "react"

class Mytown extends Component {
    constructor(props) {
        super(props)
        this.state = {
            isShowCapital: false
        }
    }

    render() {
        return (
           <h1>MY TOWN IS HALIFAX</h1>
        )
    }
}

export default Mytown;