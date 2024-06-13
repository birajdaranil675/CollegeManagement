import React, { useContext, useEffect, useState } from 'react'
import { ThemeContext } from '../contexts/Context';

function UseDarkSide() {
    const myTheme = useContext(ThemeContext);

    const [currTheme, setCurrTheme] = useState(myTheme.theme);
    const colorTheme = currTheme === 'dark' ? 'light' : 'dark';

    const toggleTheme = ()=>{
        //console.log("toggle is called...");
       const newTheme =  myTheme.theme === 'dark' ? 'light' : 'dark';
       setCurrTheme(newTheme);
    }

    useEffect(()=>{
       // console.log("inside useEffect...");
       myTheme.setTheme(currTheme);
       const root = window.document.documentElement;
        root.classList.remove(colorTheme);
        root.classList.add(currTheme);
    }, [currTheme, colorTheme])

    return[colorTheme, setCurrTheme];
}

export default UseDarkSide