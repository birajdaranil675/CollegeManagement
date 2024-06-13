import React, { useState } from "react";
import { DarkModeSwitch } from "react-toggle-dark-mode";
import UseDarkSide from "../hooks/UseDarkSide";

function SwtichTheme() {
  const [colorTheme, setCurrTheme] = UseDarkSide();
  const [isDarkMode, setDarkMode] = useState(
    colorTheme === "dark" ? true : false
  );

  const toggleDarkMode = (checked) => {
    setCurrTheme(colorTheme);
    setDarkMode(checked);
  };

  return (
    <div className="m-12 flex flex-col items-center">
      <DarkModeSwitch
        checked={isDarkMode}
        onChange={toggleDarkMode}
        size={20}
      />
      <h3 className="text-red-800 dark:text-gray-300 pt-4">{colorTheme === 'light' ? 'dark' : 'light'} mode</h3>
    </div>
  );
}

export default SwtichTheme;
