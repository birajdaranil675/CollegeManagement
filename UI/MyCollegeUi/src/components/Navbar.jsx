import React from 'react'
import { Link } from 'react-router-dom'

function Navbar() {
    const navbar = {
        
    }

  return (
    <div style={{height: '80px', width: '100%', border: '1px solid black'}}>
       <Link to='/addStudent'>addStudent</Link>
    </div>
  )
}

export default Navbar