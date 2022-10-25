import React, { Component } from "react"

// import Provinces from './components/Provinces'
// import Territories from './components/Territories'
import './App.css';
import Aboutme from "./components/Aboutme";
import Mytown from "./components/Mytown";


class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      selectedMenu: 'p'
    }
  }

  render() {
    return (
      <div className="App">
        <h1>React App</h1>
        {/* <img alt="Canada's Flag" width={125} src="https://upload.wikimedia.org/wikipedia/commons/d/d9/Flag_of_Canada_%28Pantone%29.svg" /> */}

        <div className="menu">
          <p className="menu-item" onClick={() => this.setState({ selectedMenu: 'p' })}>About Me</p>
          <p className="menu-item" onClick={() => this.setState({ selectedMenu: 't' })}>My Town</p>
        </div>

        {this.state.selectedMenu === 'p' ?
          <Aboutme />
          
          :
          <Mytown />
        }
      </div>
    );
  }
}


export default App;
