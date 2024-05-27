import { BrowserRouter, Route, RouterProvider, Routes, createBrowserRouter, createRoutesFromElements } from 'react-router-dom'
import Student from './pages/Student'
import Layout from './pages/Layout'
import Home from './pages/Home'
import NoPage from './pages/NoPage'
import AddStudent from './pages/AddStudent'
import UpdateStudentInfo from './pages/UpdateStudentInfo'

function App() {

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="/studentInfo" element={<Student />} />
            <Route path="/addStudent" element={<AddStudent />} />
            <Route path="/updateStudentInfo" element={<UpdateStudentInfo />} />
            <Route path="*" element={<NoPage />} />
      </Route>
    )
  );
  return <RouterProvider router={router}/>

  // return(
  //   <Student/>
  // )
}

export default App
