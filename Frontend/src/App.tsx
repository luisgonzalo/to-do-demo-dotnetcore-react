import React from 'react';
import './App.css';
import { Header } from './components/Header';
import { ToDoList } from './components/ToDoList';
import { makeStyles, CssBaseline } from '@material-ui/core';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
  },
}));

const App: React.FC = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <ToastContainer />
      <CssBaseline />
      <Header />
      <ToDoList />
    </div>
  );
}

export default App;
