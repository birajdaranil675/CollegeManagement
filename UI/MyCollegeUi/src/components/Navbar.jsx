import React, { useContext, useState } from 'react'
import { Link, NavLink } from 'react-router-dom'
import logo from '../assets/images/logo.png'
import { ThemeContext } from '../contexts/Context';
import SwtichTheme from './SwtichTheme';

function Navbar() {
  const linkClass = ({ isActive }) =>
    isActive
      ? 'bg-black text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2'
      : 'text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2';

  const myTheme = useContext(ThemeContext);
  console.log(myTheme);

  return (
    <nav className='bg-indigo-700 border-b border-indigo-500'>
      <div className='mx-auto max-w-7xl px-2 sm:px-6 lg:px-8'>
        <div className='flex h-20 items-center justify-between'>
          <div className='flex flex-1 items-center justify-center md:items-stretch md:justify-start'>
            <NavLink className='flex flex-shrink-0 items-center mr-4' to='/'>
              <img className='h-10 w-auto' src={logo} alt='Dautpur Institute of Technology' />
              <span className='hidden md:block text-white text-2xl font-bold ml-2'>
                Dautpur Institute of Technology
              </span>
            </NavLink>
            <div className='md:ml-auto'>
              <div className='flex space-x-2'>
                <NavLink to='/' className={linkClass}>
                  Home
                </NavLink>
                <NavLink to='/studentInfo' className={linkClass}>
                  StudentInfo
                </NavLink>
                <NavLink to='/addStudent' className={linkClass}>
                  addStudent
                </NavLink>
                <SwtichTheme/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
  )
}

export default Navbar