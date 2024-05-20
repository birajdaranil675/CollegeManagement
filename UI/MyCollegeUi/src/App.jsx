import { BrowserRouter, Route, RouterProvider, Routes, createBrowserRouter, createRoutesFromElements } from 'react-router-dom'
import Student from './pages/Student'
import Layout from './pages/Layout'
import Home from './pages/Home'
import NoPage from './pages/NoPage'
import AddStudent from './pages/AddStudent'

function App() {

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="/StudentInfo" element={<Student />} />
            <Route path="/addStudent" element={<AddStudent />} />
            <Route path="*" element={<NoPage />} />
      </Route>
    )
  );
  return <RouterProvider router={router}/>
}

export default App
